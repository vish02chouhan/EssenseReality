using EssenceRealty.Scheduler.Configurations;
using EssenceRealty.Scheduler.ExternalServices;
using EssenceRealty.Repository.IRepositories;
using EssenseReality.Domain.Models;
using System;

namespace EssenceRealty.Scheduler.Services
{
    public class VaultCrmProcessor
    {
        private readonly VaultApiClient vaultApiClient;
        private readonly VaultServicesConfig vaultServicesConfig;
        private readonly ICrmEssenceLogRepository crmEssenceLogRepository;

        public VaultCrmProcessor(VaultApiClient vaultApiClient, VaultServicesConfig vaultServicesConfig,
            ICrmEssenceLogRepository crmEssenceLogRepository)
        {
            this.vaultApiClient = vaultApiClient;
            this.vaultServicesConfig = vaultServicesConfig;
            this.crmEssenceLogRepository = crmEssenceLogRepository;
        }

        public async void StartProcessing(Guid guid)
        {
            try
            {
                foreach (var essenceMainObject in vaultServicesConfig.EssenceMainObject)
                {
                    foreach (var url in essenceMainObject.Url)
                    {
                       var data = await vaultApiClient.GetEssenceData(url);

                        CrmEssenceLog crmEssenceLog = new CrmEssenceLog
                        {
                            ProcessingGroupId = guid,
                            JsonObjectBatch = data

                        };
                     
                    }
                  
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
