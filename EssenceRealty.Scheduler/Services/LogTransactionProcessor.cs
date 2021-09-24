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
                        await SaveData(url, guid, essenceMainObject.Name);
                    }

                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task SaveData(string url, Guid processingGroupId, string objectTypeName)
        { 
            while (!string.IsNullOrEmpty(url))
            {
                using var scope = serviceProvider.CreateScope();
                var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();
                IList<CrmEssenceLog> data = await essenceLogRepo.GetCrmEssenceLog(processingGroupId);
                foreach (var item in data)
                {
                    switch (item.EssenceObjectTypes)
                    {
                        case EssenceObjectTypes.Suburbs:
                            await ProcessSubhurbMasterData(item);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private async Task ProcessSubhurbMasterData(CrmEssenceLog crmEssenceLog)
        {
            try
            {
                JObject json = JObject.Parse(crmEssenceLog.JsonObjectBatch);
                JArray items = (JArray)json["items"];
                List<State> lstStates = new List<State>();
                List<Suburb> lstSubHurbs = new List<Suburb>();

                foreach (var item in items)
                {
                    try
                    {
                        var stateData = JsonConvert.DeserializeObject<State>(item.SelectToken("state").ToString());
                        var suburbData = JsonConvert.DeserializeObject<Suburb>(item.ToString());
                        lstStates.Add(stateData);
                        lstSubHurbs.Add(suburbData);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                using var scope = serviceProvider.CreateScope();
                var stateRepo = scope.ServiceProvider.GetRequiredService<IStateRepository>();
                await stateRepo.AddStates(lstStates.GroupBy(elem => elem.Id).Select(group => group.First()).ToList());
                var subhurbRepo = scope.ServiceProvider.GetRequiredService<ISubhurbRepository>();
                await subhurbRepo.AddSubhurbs(lstSubHurbs);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

