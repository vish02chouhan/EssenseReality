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

namespace EssenceRealty.Scheduler.Services
{
    public class VaultCrmProcessor
    {
        private readonly VaultApiClient vaultApiClient;
        private readonly IOptions<VaultServicesConfig> vaultServicesConfig;
        private readonly ICrmEssenceLogRepository crmEssenceLogRepository;
        private readonly IServiceProvider serviceProvider;

        public VaultCrmProcessor(VaultApiClient vaultApiClient,
            IOptions<VaultServicesConfig> vaultServicesConfig,
             IServiceProvider serviceProvider)
        {
            this.vaultApiClient = vaultApiClient;
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
                        await SaveData(url, guid, essenceMainObject.Name);
                    }
                  
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task SaveData(string url, Guid guid, string objectTypeName)
        {
            int pageNumber = 1;
            string urlNameForDb = url;
            while (!string.IsNullOrEmpty(url))
            {
                
                
                var data = await vaultApiClient.GetEssenceData(url);
                JObject json = JObject.Parse(data);
                JArray items = (JArray)json["items"];

                CrmEssenceLog crmEssenceLog = new()
                {
                    ProcessingGroupId = guid,
                    JsonObjectBatch = data,
                    JsonObjectBatchItems = items.Count,
                    EndPointUrl = urlNameForDb,
                    RecivedDateTime = DateTime.Now,
                    ProcessedDateTime = null,
                    PageNumber = pageNumber,
                    TotalItems = Convert.ToInt32(json["totalItems"]),
                    Status = LogTransactionStatus.Pending,
                    EssenceObjectTypes = (EssenceObjectTypes)Enum.Parse(typeof(EssenceObjectTypes), objectTypeName, true),
                };

                using var scope = serviceProvider.CreateScope();
                var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();

                await essenceLogRepo.AddCrmEssenceLog(crmEssenceLog);

                pageNumber++;
                url = json["urls"]["next"].ToString();
            }
        }
    }
}
