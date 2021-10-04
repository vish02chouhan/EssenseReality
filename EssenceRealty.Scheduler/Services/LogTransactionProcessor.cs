﻿using EssenceRealty.Scheduler.Configurations;
using EssenceRealty.Scheduler.ExternalServices;
using EssenceRealty.Repository.IRepositories;
using EssenseReality.Domain.Models;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using EssenceRealty.Scheduler.ServiceProcessors;

namespace EssenceRealty.Scheduler.Services
{
    public class LogTransactionProcessor
    {
        private readonly IOptions<VaultServicesConfig> vaultServicesConfig;
        private readonly IServiceProvider serviceProvider;

        public LogTransactionProcessor(IOptions<VaultServicesConfig> vaultServicesConfig,
             IServiceProvider serviceProvider)
        {
            this.vaultServicesConfig = vaultServicesConfig;
            this.serviceProvider = serviceProvider;
        }

        public async Task StartProcessing(Guid guid)
        {
            try
            {

                await ProcessLogData(guid);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task ProcessLogData(Guid processingGroupId)
        {

            using var scope = serviceProvider.CreateScope();
            var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();
            IList<CrmEssenceLog> essenceDataObjects = await essenceLogRepo.GetCrmEssenceLog(processingGroupId);
            foreach (var essenceDataObject in essenceDataObjects)
            {
                try
                {
                    JArray essenceDataObjectArray = JArray.Parse(essenceDataObject.JsonObjectBatch);
 
                    // JArray items = (JArray)json["items"];
                    switch (essenceDataObject.EssenceObjectTypes)
                    {
                        case EssenceObjectTypes.Suburbs:
                            SuburbProcessor suburbProcessor = new();
                            await suburbProcessor.ProcessSubhurbMasterData(serviceProvider, essenceDataObjectArray);
                            break;
                        case EssenceObjectTypes.PropertyClass:
                            PropertyClassProcessor propertyClassProcessor = new();
                            await propertyClassProcessor.ProcessPropertyClassMasterData(serviceProvider, essenceDataObjectArray);
                            break;
                        case EssenceObjectTypes.PropertyType:
                            PropertyTypeProcessor propertyTypeProcessor = new();
                            await propertyTypeProcessor.ProcessPropertyTypeMasterData(serviceProvider, essenceDataObjectArray);
                            break;
                        case EssenceObjectTypes.Contacts:
                            ContactStaffProcessor contactStaffProcessor = new();
                            await contactStaffProcessor.ProcessContactStaffData(serviceProvider, essenceDataObjectArray);
                            break;
                        case EssenceObjectTypes.Property:
                            PropertyProcessor propertyProcessor = new();
                            await propertyProcessor.ProcessPropertyData(serviceProvider, essenceDataObjectArray);
                            break;
                        default:
                            break;
                    }
                    essenceDataObject.Status = LogTransactionStatus.Processed;
                    await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);
                }
                catch (Exception ex) //need to improve exception handling
                {
                    essenceDataObject.Status = LogTransactionStatus.Failed;
                    essenceDataObject.Retry = essenceDataObject.Retry + 1;
                    await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);

                    CrmEssenceTransaction crmEssenceTransaction = new()
                    {
                        CreatedBy = "ProcessLogData",
                        //Description = ex.Message,
                        JsonObject = essenceDataObject.JsonObjectBatch,
                        //Retry = item.Retry + 1,
                        EssenceObjectTypes = essenceDataObject.EssenceObjectTypes,
                        CrmEssenceLogId = essenceDataObject.Id,
                        //Status = LogTransactionStatus.Failed,
                        CrmEssenceLog = essenceDataObject
                    };
                    var essenceTransactionRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceTransactionRepository>();
                    await essenceTransactionRepo.AddCrmEssenceLog(crmEssenceTransaction);

                }
            }
        }
        
    }
}

