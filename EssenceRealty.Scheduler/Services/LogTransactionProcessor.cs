using EssenceRealty.Scheduler.Configurations;
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
                foreach (var essenceMainObject in vaultServicesConfig.Value.EssenceMainObject)
                {
                    foreach (var url in essenceMainObject.Urls)
                    {
                        await ProcessLogData(url, guid, essenceMainObject.Name);
                    }

                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task ProcessLogData(string url, Guid processingGroupId, string objectTypeName)
        { 
            while (!string.IsNullOrEmpty(url))
            {
                using var scope = serviceProvider.CreateScope();
                var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();
                IList<CrmEssenceLog> data = await essenceLogRepo.GetCrmEssenceLog(processingGroupId);
                foreach (var item in data)
                {
                    try
                    {
                        JObject json = JObject.Parse(item.JsonObjectBatch);
                        JArray items = (JArray)json["items"];
                        switch (item.EssenceObjectTypes)
                        {
                            case EssenceObjectTypes.Suburbs:
                                SuburbProcessor suburbProcessor = new SuburbProcessor();
                                await suburbProcessor.ProcessSubhurbMasterData(serviceProvider, items);
                                break;
                            case EssenceObjectTypes.PropertyClass:
                                PropertyClassProcessor propertyClassProcessor = new PropertyClassProcessor();
                                await propertyClassProcessor.ProcessPropertyClassMasterData(serviceProvider, items);
                                break;
                            case EssenceObjectTypes.PropertyType:
                                PropertyTypeProcessor propertyTypeProcessor = new PropertyTypeProcessor();
                                await propertyTypeProcessor.ProcessPropertyTypeMasterData(serviceProvider, items);
                                break;
                            case EssenceObjectTypes.Contacts:
                                ContactStaffProcessor contactStaffProcessor = new ContactStaffProcessor();
                                await contactStaffProcessor.ProcessContactStaffData(serviceProvider, items);
                                break;
                            default:
                                break;
                        }
                        item.Status = LogTransactionStatus.Processed;
                        await essenceLogRepo.UpdateCrmEssenceLog(item);
                    }
                    catch (Exception ex) //need to improve exception handling
                    {
                        item.Status = LogTransactionStatus.Failed;
                        item.Retry = item.Retry + 1;
                        await essenceLogRepo.UpdateCrmEssenceLog(item);

                        CrmEssenceTransaction crmEssenceTransaction = new CrmEssenceTransaction()
                        {
                            CreatedBy = "ProcessLogData",
                            //Description = ex.Message,
                            JsonObject = item.JsonObjectBatch,
                            //Retry = item.Retry + 1,
                            EssenceObjectTypes = (EssenceObjectTypes)Enum.Parse(typeof(EssenceObjectTypes), objectTypeName, true),
                            CrmEssenceLogId = item.Id,
                            //Status = LogTransactionStatus.Failed,
                            CrmEssenceLog = item
                        };
                        var essenceTransactionRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceTransactionRepository>();
                        await essenceTransactionRepo.AddCrmEssenceLog(crmEssenceTransaction);

                    }
                }
            }
        }
    }
}

