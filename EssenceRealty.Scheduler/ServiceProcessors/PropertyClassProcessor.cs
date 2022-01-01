using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Scheduler.ServiceProcessors
{
    public class PropertyClassProcessor:IProcessEssence
    {
        private readonly IServiceProvider serviceProvider;
        public PropertyClassProcessor(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task ProcessJsonData(CrmEssenceLog objCrmEssenceLog)
        {
            var items = JArray.Parse(objCrmEssenceLog.JsonObjectBatch);
            try
            {
                var lstPropertyClass = ExtractPropertyClassData(items);
                using var scope = serviceProvider.CreateScope();
                await UpsertPropertyClassData(scope, lstPropertyClass);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public List<PropertyClass> ExtractPropertyClassData(JArray items)
        {
            return JsonConvert.DeserializeObject<IList<PropertyClass>>(items.ToString())
                                  .Where(x => x != null && x.Id > 0).ToList()
                                  .Select<PropertyClass, PropertyClass>(p => new PropertyClass
                                  {
                                      Id = 0,
                                      Name = p.Name,
                                      CrmPropertyClassId = p.Id,
                                      InternalName = p.InternalName,
                                      CreatedBy = ERConstants.PROPERTYCLASS_PROCESSOR,
                                      CreatedDate = DateTime.Now,
                                      ModifiedDate = DateTime.Now,
                                      ModifieldBy = ERConstants.PROPERTYCLASS_PROCESSOR
                                  }).ToList();
        }
        public async Task UpsertPropertyClassData(IServiceScope scope, List<PropertyClass> lstPropertyClass)
        {
            var proprtyClassRepo = scope.ServiceProvider.GetRequiredService<IPropertyClassRepository>();
            await proprtyClassRepo.UpsertPropertyClasses(lstPropertyClass);
        }
    }
}
