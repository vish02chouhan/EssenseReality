﻿using EssenceRealty.Scheduler.Configurations;
using EssenceRealty.Scheduler.ExternalServices;
using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Domain.Models;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using EssenceRealty.Scheduler.ServiceProcessors;
using EssenceRealty.Domain.Enums;

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

        public async Task StartProcessing(Guid guid, VaultCrmProcessor vaultCrmProcessor)
        {
            try
            {
                await ProcessLogData(guid, vaultCrmProcessor);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task ProcessLogData(Guid processingGroupId, VaultCrmProcessor vaultCrmProcessor)
        {

            using var scope = serviceProvider.CreateScope();
            var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();

            IList<CrmEssenceLog> essenceDataObjects = await essenceLogRepo.GetCrmEssenceLog(processingGroupId);
            List<int?> lstVaultPropertyId = new();

            foreach (var essenceDataObject in essenceDataObjects)
            {
                try
                {
                    var essenceDataObjectArray = JArray.Parse(essenceDataObject.JsonObjectBatch);

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
                            lstVaultPropertyId.AddRange(await propertyProcessor.ProcessPropertyData(serviceProvider, essenceDataObjectArray, essenceDataObject.EndPointUrl));

                            await GetPropertFeatureFromCRM(essenceDataObjectArray, processingGroupId, vaultCrmProcessor);

                            await GetOpenHomeFromCRM(essenceDataObjectArray, processingGroupId, vaultCrmProcessor, essenceDataObject.EndPointUrl);
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
                        ErrorDescription = ex.Message,
                        JsonObject = essenceDataObject.JsonObjectBatch,
                        EssenceObjectTypes = essenceDataObject.EssenceObjectTypes,
                        CrmEssenceLogId = essenceDataObject.Id,
                        CrmEssenceLog = essenceDataObject
                    };
                    var essenceTransactionRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceTransactionRepository>();
                    await essenceTransactionRepo.AddCrmEssenceLog(crmEssenceTransaction);

                }
            }
            if(lstVaultPropertyId.Count > 0)
            {
                await UpdatePropertyNotExistsInCRM(lstVaultPropertyId);
            }
        }

        private async Task UpdatePropertyNotExistsInCRM(List<int?> lstVaultPropertyId)
        {
            PropertyProcessor propertyProcessor = new();
            await propertyProcessor.UpdatePropertyNotExistsInCRM(this.serviceProvider , lstVaultPropertyId);
        }

        private async Task GetPropertFeatureFromCRM(JArray items, Guid processingGroupId, VaultCrmProcessor vaultCrmProcessor)
        {
            foreach (var item in items)
            {
                int crmPropertyId = Convert.ToInt32(item["id"]);
                string propertFeatureUrl = this.vaultServicesConfig.Value.EssenceMainObject
                                            .Where(x => x.Name == "PropertyFeature")
                                            .Select(y => y.Urls).FirstOrDefault().FirstOrDefault().ToString()
                                            .Replace("propertyId", crmPropertyId.ToString());

                await vaultCrmProcessor.SaveData(propertFeatureUrl, processingGroupId, "PropertyFeatures");
                using var scope = serviceProvider.CreateScope();
                var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();
                CrmEssenceLog essenceDataObject = await essenceLogRepo.GetPropertyFeatureJson(processingGroupId, crmPropertyId);
                JArray essenceDataObjectArray = JArray.Parse(essenceDataObject.JsonObjectBatch);
                PropertyFeaturesProcessor objPropertyFeaturesProcessor = new();
                await objPropertyFeaturesProcessor.ProcessPropertyFeaturesData(serviceProvider, essenceDataObjectArray, crmPropertyId);
                essenceDataObject.Status = LogTransactionStatus.Processed;
                await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);
            }
        }

        private async Task GetOpenHomeFromCRM(JArray items, Guid processingGroupId, VaultCrmProcessor vaultCrmProcessor, string endPointURL)
        {
            foreach (var item in items)
            {
                dynamic data = JsonConvert.DeserializeObject(item.ToString());
                
                PropertyProcessor objPropertyProcessor = new();
                string propertyTranasctionType = objPropertyProcessor.CalculateStatus(endPointURL, data.status?.ToString());
                if (propertyTranasctionType.ToUpper() != PropertTransactionType.Sold.ToString().ToUpper())
                {
                    int? lifeID = propertyTranasctionType.ToUpper() == PropertTransactionType.Sale.ToString().ToUpper() ? data.saleLifeId : data.leaseLifeId;
                    int crmPropertyId = Convert.ToInt32(data.id);

                    string openHomeUrl = this.vaultServicesConfig.Value.EssenceMainObject
                                                .Where(x => x.Name == "OpenHome")
                                                .Select(y => y.Urls).FirstOrDefault().FirstOrDefault().ToString()
                                                .Replace("propertyId", crmPropertyId.ToString());
                    openHomeUrl = openHomeUrl.Replace("propertyTransactionType", propertyTranasctionType.ToLower());
                    openHomeUrl = openHomeUrl.Replace("lifeId", lifeID.ToString());

                    await vaultCrmProcessor.SaveData(openHomeUrl, processingGroupId, "OpenHome");
                    using var scope = serviceProvider.CreateScope();
                    var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();
                    CrmEssenceLog essenceDataObject = await essenceLogRepo.GetOpenHomeJson(processingGroupId, crmPropertyId);
                    JArray essenceDataObjectArray = JArray.Parse(essenceDataObject.JsonObjectBatch);
                    OpenHomeProcessor objOpenHomeProcessor = new();
                    await objOpenHomeProcessor.ProcessOpenHomeData(serviceProvider, essenceDataObjectArray, crmPropertyId);
                    essenceDataObject.Status = LogTransactionStatus.Processed;
                    await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);
                }
            }
        }
    }
}

