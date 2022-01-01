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
        private readonly IEnumerable<IProcessEssence> processEssences;

        public LogTransactionProcessor(IOptions<VaultServicesConfig> vaultServicesConfig,
             IServiceProvider serviceProvider, IEnumerable<IProcessEssence> processEssences)
        {
            this.vaultServicesConfig = vaultServicesConfig;
            this.serviceProvider = serviceProvider;
            this.processEssences = processEssences;
        }

        public async Task StartProcessing(Guid guid)
        {
            try
            {
                foreach (var obj in this.processEssences)
                {
                    await ProcessLogData(guid, obj);
                }
                //foreach (var essenceMainObject in vaultServicesConfig.Value.EssenceMainObject.OrderBy(x => x.Priority))
                //{
                //    if ((!essenceMainObject.IsRequiredToProcess) || (essenceMainObject.RunsOnDay != DateTime.Now.Day && essenceMainObject.RunsOnDay != 0))
                //    {
                //        continue;
                //    }
                //    await ProcessLogData(guid, essenceMainObject);
                //}
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task ProcessLogData(Guid processingGroupId, IProcessEssence objEssenceProcessor)
        {
            string str = objEssenceProcessor.GetType().FullName.Split('.').Last().Replace("Processor", "");
            var name = (EssenceObjectTypes)Enum.Parse(typeof(EssenceObjectTypes), str, true);
            EssenceMainObject essenceMainObject = vaultServicesConfig.Value.EssenceMainObject.Where(x => x.Name == name.ToString()).First();
            IList<CrmEssenceLog> objCrmEssenceLog = await GetJsonFromDBForProcessing(processingGroupId, essenceMainObject);

            List<int?> lstVaultPropertyId = new();

            foreach (var essenceDataObject in objCrmEssenceLog)
            {
                try
                {
                    await objEssenceProcessor.ProcessJsonData(essenceDataObject);
                    //var essenceDataObjectArray = JArray.Parse(essenceDataObject.JsonObjectBatch);

                    //IProcessEssence objProcessEssence = GetProcessorObject(essenceMainObject.Name);
                    //await objProcessEssence.ProcessJsonData(essenceDataObject);

                    essenceDataObject.Status = LogTransactionStatus.Processed;
                    //await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);
                }
                catch (Exception ex) //need to improve exception handling
                {
                    essenceDataObject.Status = LogTransactionStatus.Failed;
                    essenceDataObject.Retry = essenceDataObject.Retry + 1;
                    //await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);

                    CrmEssenceTransaction crmEssenceTransaction = new()
                    {
                        CreatedBy = "ProcessLogData",
                        ErrorDescription = ex.Message,
                        JsonObject = essenceDataObject.JsonObjectBatch,
                        EssenceObjectTypes = essenceDataObject.EssenceObjectTypes,
                        CrmEssenceLogId = essenceDataObject.Id,
                        CrmEssenceLog = essenceDataObject
                    };
                    //var essenceTransactionRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceTransactionRepository>();
                    //await essenceTransactionRepo.AddCrmEssenceLog(crmEssenceTransaction);

                }
            }

            //if (lstVaultPropertyId.Count > 0)
            //{
            //    await UpdatePropertyNotExistsInCRM(lstVaultPropertyId);
            //}
        }

        //public async Task ProcessLogData(Guid processingGroupId, EssenceMainObject essenceMainObject)
        //{
        //    IList<CrmEssenceLog> objCrmEssenceLog = await GetJsonFromDBForProcessing(processingGroupId, essenceMainObject);

        //    List<int?> lstVaultPropertyId = new();

        //    foreach (var essenceDataObject in objCrmEssenceLog)
        //    {
        //        try
        //        {
        //            //var essenceDataObjectArray = JArray.Parse(essenceDataObject.JsonObjectBatch);

        //            IProcessEssence objProcessEssence = this.processEssences.First(x => x.GetType().ToString().Contains(essenceMainObject.Name.Substring(0,essenceMainObject.Name.Length-2)));//GetProcessorObject(essenceMainObject.Name);
        //            await objProcessEssence.ProcessJsonData(essenceDataObject);

        //            essenceDataObject.Status = LogTransactionStatus.Processed;
        //            //await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);
        //        }
        //        catch (Exception ex) //need to improve exception handling
        //        {
        //            essenceDataObject.Status = LogTransactionStatus.Failed;
        //            essenceDataObject.Retry = essenceDataObject.Retry + 1;
        //            //await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);

        //            CrmEssenceTransaction crmEssenceTransaction = new()
        //            {
        //                CreatedBy = "ProcessLogData",
        //                ErrorDescription = ex.Message,
        //                JsonObject = essenceDataObject.JsonObjectBatch,
        //                EssenceObjectTypes = essenceDataObject.EssenceObjectTypes,
        //                CrmEssenceLogId = essenceDataObject.Id,
        //                CrmEssenceLog = essenceDataObject
        //            };
        //            //var essenceTransactionRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceTransactionRepository>();
        //            //await essenceTransactionRepo.AddCrmEssenceLog(crmEssenceTransaction);

        //        }
        //    }

        //    //if (lstVaultPropertyId.Count > 0)
        //    //{
        //    //    await UpdatePropertyNotExistsInCRM(lstVaultPropertyId);
        //    //}
        //}

        //private IProcessEssence GetProcessorObject(string name)
        //{
        //    return (EssenceObjectTypes)Enum.Parse(typeof(EssenceObjectTypes), name, true) switch
        //    {
        //        EssenceObjectTypes.Suburbs => new SuburbProcessor(),
        //        EssenceObjectTypes.PropertyClass => new PropertyClassProcessor(),
        //        EssenceObjectTypes.PropertyType => new PropertyTypeProcessor(),
        //        EssenceObjectTypes.Contacts => new ContactStaffProcessor(),
        //        EssenceObjectTypes.Property => new PropertyProcessor(),
        //        _ => null,
        //    };
        //}

        private async Task<IList<CrmEssenceLog>> GetJsonFromDBForProcessing(Guid processingGroupId, EssenceMainObject essenceMainObject)
        {
            using var scope = serviceProvider.CreateScope();
            var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();

            return await essenceLogRepo.GetCrmEssenceLog(processingGroupId, (EssenceObjectTypes)Enum.Parse(typeof(EssenceObjectTypes), essenceMainObject.Name, true));
        }

        //public async Task ProcessLogData(Guid processingGroupId, VaultCrmProcessor vaultCrmProcessor)
        //{

        //    using var scope = serviceProvider.CreateScope();
        //    var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();

        //    IList<CrmEssenceLog> essenceDataObjects = await essenceLogRepo.GetCrmEssenceLog(processingGroupId);
        //    List<int?> lstVaultPropertyId = new();

        //    foreach (var essenceDataObject in essenceDataObjects)
        //    {
        //        try
        //        {
        //            var essenceDataObjectArray = JArray.Parse(essenceDataObject.JsonObjectBatch);

        //            switch (essenceDataObject.EssenceObjectTypes)
        //            {
        //                case EssenceObjectTypes.Suburbs:
        //                    SuburbProcessor suburbProcessor = new();
        //                    await suburbProcessor.ProcessSubhurbMasterData(serviceProvider, essenceDataObjectArray);
        //                    break;
        //                case EssenceObjectTypes.PropertyClass:
        //                    PropertyClassProcessor propertyClassProcessor = new();
        //                    await propertyClassProcessor.ProcessPropertyClassMasterData(serviceProvider, essenceDataObjectArray);
        //                    break;
        //                case EssenceObjectTypes.PropertyType:
        //                    PropertyTypeProcessor propertyTypeProcessor = new();
        //                    await propertyTypeProcessor.ProcessPropertyTypeMasterData(serviceProvider, essenceDataObjectArray);
        //                    break;
        //                case EssenceObjectTypes.Contacts:
        //                    ContactStaffProcessor contactStaffProcessor = new();
        //                    await contactStaffProcessor.ProcessContactStaffData(serviceProvider, essenceDataObjectArray);
        //                    break;
        //                case EssenceObjectTypes.Property:
        //                    PropertyProcessor propertyProcessor = new();
        //                    lstVaultPropertyId.AddRange(await propertyProcessor.ProcessPropertyData(serviceProvider, essenceDataObjectArray, essenceDataObject.EndPointUrl));

        //                    await GetPropertFeatureFromCRM(essenceDataObjectArray, processingGroupId, vaultCrmProcessor);

        //                    await GetOpenHomeFromCRM(essenceDataObjectArray, processingGroupId, vaultCrmProcessor, essenceDataObject.EndPointUrl);
        //                    break;
        //                default:
        //                    break;
        //            }
        //            essenceDataObject.Status = LogTransactionStatus.Processed;
        //            await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);
        //        }
        //        catch (Exception ex) //need to improve exception handling
        //        {
        //            essenceDataObject.Status = LogTransactionStatus.Failed;
        //            essenceDataObject.Retry = essenceDataObject.Retry + 1;
        //            await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);

        //            CrmEssenceTransaction crmEssenceTransaction = new()
        //            {
        //                CreatedBy = "ProcessLogData",
        //                ErrorDescription = ex.Message,
        //                JsonObject = essenceDataObject.JsonObjectBatch,
        //                EssenceObjectTypes = essenceDataObject.EssenceObjectTypes,
        //                CrmEssenceLogId = essenceDataObject.Id,
        //                CrmEssenceLog = essenceDataObject
        //            };
        //            var essenceTransactionRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceTransactionRepository>();
        //            await essenceTransactionRepo.AddCrmEssenceLog(crmEssenceTransaction);

        //        }
        //    }

        //    if(lstVaultPropertyId.Count > 0)
        //    {
        //        await UpdatePropertyNotExistsInCRM(lstVaultPropertyId);
        //    }
        //}

        //private async Task UpdatePropertyNotExistsInCRM(List<int?> lstVaultPropertyId)
        //{
        //    PropertyProcessor propertyProcessor = new();
        //    await propertyProcessor.UpdatePropertyNotExistsInCRM(this.serviceProvider , lstVaultPropertyId);
        //}

        //private async Task GetPropertFeatureFromCRM(JArray items, Guid processingGroupId, VaultCrmProcessor vaultCrmProcessor)
        //{
        //    foreach (var item in items)
        //    {
        //        int crmPropertyId = Convert.ToInt32(item["id"]);
        //        string propertFeatureUrl = this.vaultServicesConfig.Value.EssenceMainObject
        //                                    .Where(x => x.Name == "PropertyFeature")
        //                                    .Select(y => y.Urls).FirstOrDefault().FirstOrDefault().ToString()
        //                                    .Replace("propertyId", crmPropertyId.ToString());

        //        await vaultCrmProcessor.SaveData(propertFeatureUrl, processingGroupId, "PropertyFeatures");
        //        using var scope = serviceProvider.CreateScope();
        //        var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();
        //        CrmEssenceLog essenceDataObject = await essenceLogRepo.GetPropertyFeatureJson(processingGroupId, crmPropertyId);
        //        JArray essenceDataObjectArray = JArray.Parse(essenceDataObject.JsonObjectBatch);
        //        PropertyFeaturesProcessor objPropertyFeaturesProcessor = new();
        //        await objPropertyFeaturesProcessor.ProcessPropertyFeaturesData(serviceProvider, essenceDataObjectArray, crmPropertyId);
        //        essenceDataObject.Status = LogTransactionStatus.Processed;
        //        await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);
        //    }
        //}

        //private async Task GetOpenHomeFromCRM(JArray items, Guid processingGroupId, VaultCrmProcessor vaultCrmProcessor, string endPointURL)
        //{
        //    foreach (var item in items)
        //    {
        //        dynamic data = JsonConvert.DeserializeObject(item.ToString());

        //        PropertyProcessor objPropertyProcessor = new();
        //        string propertyTranasctionType = objPropertyProcessor.CalculateStatus(endPointURL, data.status?.ToString());
        //        if (propertyTranasctionType.ToUpper() != PropertTransactionType.Sold.ToString().ToUpper())
        //        {
        //            int? lifeID = propertyTranasctionType.ToUpper() == PropertTransactionType.Sale.ToString().ToUpper() ? data.saleLifeId : data.leaseLifeId;
        //            int crmPropertyId = Convert.ToInt32(data.id);

        //            string openHomeUrl = this.vaultServicesConfig.Value.EssenceMainObject
        //                                        .Where(x => x.Name == "OpenHome")
        //                                        .Select(y => y.Urls).FirstOrDefault().FirstOrDefault().ToString()
        //                                        .Replace("propertyId", crmPropertyId.ToString());
        //            openHomeUrl = openHomeUrl.Replace("propertyTransactionType", propertyTranasctionType.ToLower());
        //            openHomeUrl = openHomeUrl.Replace("lifeId", lifeID.ToString());

        //            await vaultCrmProcessor.SaveData(openHomeUrl, processingGroupId, "OpenHome");
        //            using var scope = serviceProvider.CreateScope();
        //            var essenceLogRepo = scope.ServiceProvider.GetRequiredService<ICrmEssenceLogRepository>();
        //            CrmEssenceLog essenceDataObject = await essenceLogRepo.GetOpenHomeJson(processingGroupId, crmPropertyId);
        //            JArray essenceDataObjectArray = JArray.Parse(essenceDataObject.JsonObjectBatch);
        //            OpenHomeProcessor objOpenHomeProcessor = new();
        //            await objOpenHomeProcessor.ProcessOpenHomeData(serviceProvider, essenceDataObjectArray, crmPropertyId);
        //            essenceDataObject.Status = LogTransactionStatus.Processed;
        //            await essenceLogRepo.UpdateCrmEssenceLog(essenceDataObject);
        //        }
        //    }
        //}
    }
}