using EssenceRealty.Repository.IRepositories;
using EssenseReality.Domain.Models;
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
    public class PropertyClassProcessor
    {
        public async Task ProcessPropertyClassMasterData(IServiceProvider serviceProvider, JArray items)
        {
            try
            {
                var lstPropertyClass = ExtractPropertyClassData(items);
                using var scope = serviceProvider.CreateScope();
                await UpsertPropertyClassData(scope, lstPropertyClass);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
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
