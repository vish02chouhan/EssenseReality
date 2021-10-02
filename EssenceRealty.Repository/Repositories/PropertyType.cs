using EssenceRealty.Repository.IRepositories;
using EssenseReality.Data;
using EssenseReality.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class PropertyTypeRepository : BaseRepository<PropertyType>, IPropertyTypeRepository
    {
        public PropertyTypeRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPropertyTypes(IList<PropertyType> lstPropertyType)
        {
            var lstUpdatedPropertClasses = _dbContext.PropertyClasses.ToList();
            foreach (var item in lstPropertyType)
            {
                item.PropertyClassId = lstUpdatedPropertClasses.Where(x => x.CrmPropertyClassId == item.PropertyClass.CrmPropertyClassId).First().Id;
                item.PropertyClass = lstUpdatedPropertClasses.Where(x => x.CrmPropertyClassId == item.PropertyClass.CrmPropertyClassId  ).First();
            }
            await _dbContext.PropertyTypes.UpsertRange(lstPropertyType).On(x => x.CrmPropertyTypeId).RunAsync();
            await _dbContext.SaveChangesAsync();

        }
    }
}
