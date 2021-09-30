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
                var lstPropertyTypes = JsonConvert.DeserializeObject<IList<PropertyType>>(items.ToString())
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
                                          CreatedBy = "PropertyTypeProcessor",
                                          CreatedDate = DateTime.Now,
                                          ModifiedDate = DateTime.Now,
                                          ModifieldBy = "PropertyTypeProcessor"
                                      },
                                      CreatedBy = "PropertyTypeProcessor",
                                      CreatedDate = DateTime.Now,
                                      ModifiedDate = DateTime.Now,
                                      ModifieldBy = "PropertyTypeProcessor"
                                  }).ToList();
                
                var lstPropertyClass = lstPropertyTypes.Select(x => x.PropertyClass)
                            .Where(x => x != null && x.CrmPropertyClassId > 0).ToList()
                            .GroupBy(elem => elem.CrmPropertyClassId)
                            .Select(group => group.First()).ToList();

                using var scope = serviceProvider.CreateScope();
                var proprtyClassRepo = scope.ServiceProvider.GetRequiredService<IPropertyClassRepository>();
                await proprtyClassRepo.UpsertPropertyClasses(lstPropertyClass);
                var propertTypeRepo = scope.ServiceProvider.GetRequiredService<IPropertyTypeRepository>();
                await propertTypeRepo.UpsertPropertyTypes(lstPropertyTypes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
