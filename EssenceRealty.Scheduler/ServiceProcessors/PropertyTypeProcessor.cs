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
    public class PropertyTypeProcessor
    {
        public async Task ProcessPropertyTypeMasterData(IServiceProvider serviceProvider, JArray items)
        {
            try
            {
                var lstPropertyTypes = ExtractPropertyTypeData(items);

                var lstPropertyClass = ExtractPropertyClassData(lstPropertyTypes);

                using var scope = serviceProvider.CreateScope();
                PropertyClassProcessor propertyClassProcessor = new();
                await propertyClassProcessor.UpsertPropertyClassData(scope, lstPropertyClass);
                await UpsertPropertyTypeData(scope, lstPropertyTypes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public List<PropertyType> ExtractPropertyTypeData(JArray items)
        {
            return JsonConvert.DeserializeObject<IList<PropertyType>>(items.ToString())
                                  .Where(x => x != null && x.Id > 0).ToList()
                                  .Select<PropertyType, PropertyType>(p => new PropertyType
                                  {
                                      Id = 0,
                                      Name = p.Name,
                                      CrmPropertyTypeId = p.Id,
                                      PropertyClass = new PropertyClass()
                                      {
                                          CrmPropertyClassId = p.PropertyClass.Id,
                                          InternalName = p.PropertyClass.InternalName,
                                          Name = p.PropertyClass.Name,
                                          CreatedBy = ERConstants.PROPERTYTYPE_PROCESSOR,
                                          CreatedDate = DateTime.Now,
                                          ModifiedDate = DateTime.Now,
                                          ModifieldBy = ERConstants.PROPERTYTYPE_PROCESSOR
                                      },
                                      CreatedBy = ERConstants.PROPERTYTYPE_PROCESSOR,
                                      CreatedDate = DateTime.Now,
                                      ModifiedDate = DateTime.Now,
                                      ModifieldBy = ERConstants.PROPERTYTYPE_PROCESSOR
                                  }).ToList();
        }
        public List<PropertyClass> ExtractPropertyClassData(List<PropertyType> lstPropertyTypes)
        {
            return lstPropertyTypes.Select(x => x.PropertyClass)
                            .Where(x => x != null && x.CrmPropertyClassId > 0).ToList()
                            .GroupBy(elem => elem.CrmPropertyClassId)
                            .Select(group => group.First()).ToList();
        }
        public async Task UpsertPropertyTypeData(IServiceScope scope, List<PropertyType> lstPropertyType)
        {
            var propertTypeRepo = scope.ServiceProvider.GetRequiredService<IPropertyTypeRepository>();
            await propertTypeRepo.UpsertPropertyTypes(lstPropertyType.GroupBy(elem => elem.CrmPropertyTypeId).Select(group => group.First()).ToList());
        }
    }
}
