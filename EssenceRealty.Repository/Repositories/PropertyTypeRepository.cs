using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;
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
        public PropertyTypeRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPropertyTypes(List<PropertyType> lstPropertyType)
        {
            var lstPropertyTypeIds = lstPropertyType.Select(x => x.CrmPropertyTypeId).Distinct().ToList();
            var lstDBCrmPropertyTypeIds = _dbContext.PropertyTypes.Where(x => lstPropertyTypeIds.Contains(x.CrmPropertyTypeId)).Select(x => x.CrmPropertyTypeId).Distinct().ToList();
            lstPropertyType.RemoveAll(x => lstDBCrmPropertyTypeIds.Contains(x.CrmPropertyTypeId));
            if (lstPropertyType.Count > 0)
            {
                var lstPropertyClassesIds = lstPropertyType.Select(x => x.PropertyClass.CrmPropertyClassId).Distinct().ToList();
                var lstDBPropertyClassesDetails = _dbContext.PropertyClasses.Where(x => lstPropertyClassesIds.Contains(x.CrmPropertyClassId)).Select(x => new { Id = x.Id, CrmPropertyClassId = x.CrmPropertyClassId }).Distinct().ToList();
                foreach (var item in lstPropertyType)
                {
                    item.PropertyClassId = lstDBPropertyClassesDetails.Where(x => x.CrmPropertyClassId == item.PropertyClass.CrmPropertyClassId).First().Id;
                }
                await _dbContext.PropertyTypes.UpsertRange(lstPropertyType).On(x => x.CrmPropertyTypeId).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
