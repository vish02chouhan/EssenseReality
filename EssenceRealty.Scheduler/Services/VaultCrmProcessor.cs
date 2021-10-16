using EssenceRealty.Scheduler.Configurations;
using EssenceRealty.Scheduler.ExternalServices;
using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Domain.Models;
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
        private readonly int pageSize;
        private readonly IServiceProvider serviceProvider;

        public VaultCrmProcessor(VaultApiClient vaultApiClient,
            IOptions<VaultServicesConfig> vaultServicesConfig,
             IServiceProvider serviceProvider)
        {
            this.vaultApiClient = vaultApiClient;
            this.vaultServicesConfig = vaultServicesConfig;
            this.serviceProvider = serviceProvider;
            this.pageSize = vaultServicesConfig.Value.PageSize;
        }

        public async Task StartProcessing(Guid guid)
        {
            try
            {
                foreach (var essenceMainObject in vaultServicesConfig.Value.EssenceMainObject)
                {
                    if (!essenceMainObject.IsRequiredToProcess)
                    {
                        continue;
                    }

                    foreach (var url in essenceMainObject.Urls)
                    {
                        try
                        {
                            await SaveData(url, guid, essenceMainObject.Name);
                        }
                        catch (Exception)
                        {
                            //To Do; Will implement exception
                        }
                      
                    }
                  
                }
            }
            catch (System.Exception)
            {
                //To Do; Will implement exception
            }
        }

        public async Task SaveData(string url, Guid guid, string objectTypeName)
        {
            int pageNumber = 1;
            string urlNameForDb = url;
            url = url + "?pagesize=" + pageSize;

            using var scope = serviceProvider.CreateScope();
            var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();

            while (!string.IsNullOrEmpty(url))
            {
                              
                var data = await vaultApiClient.GetEssenceData(url);
                JObject json = JObject.Parse(data);
                JArray items = (JArray)json["items"];

                CrmEssenceLog crmEssenceLog = new()
                {
                    ProcessingGroupId = guid,
                    JsonObjectBatch = json["items"].ToString(),
                    JsonObjectBatchItems = items.Count,
                    EndPointUrl = urlNameForDb,
                    RecivedDateTime = DateTime.Now,
                    ProcessedDateTime = null,
                    PageNumber = pageNumber,
                    TotalItems = Convert.ToInt32(json["totalItems"]),
                    Status = LogTransactionStatus.Pending,
                    EssenceObjectTypes = (EssenceObjectTypes)Enum.Parse(typeof(EssenceObjectTypes), objectTypeName, true),
                };
               
                await essenceLogRepo.AddCrmEssenceLog(crmEssenceLog);

                pageNumber++;
                url = json["urls"]["next"].ToString();
            }
        }
    }
}
