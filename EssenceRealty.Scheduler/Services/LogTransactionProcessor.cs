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
                    JObject json = JObject.Parse(item.JsonObjectBatch);
                    JArray items = (JArray)json["items"];
                    switch (item.EssenceObjectTypes)
                    {
                        case EssenceObjectTypes.Suburbs:
                            SuburbProcessor suburbProcessor = new SuburbProcessor();
                            await suburbProcessor.ProcessSubhurbMasterData(serviceProvider,items);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}

