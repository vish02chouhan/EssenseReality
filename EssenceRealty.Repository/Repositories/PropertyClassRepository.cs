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
    public class PropertyClassRepository : BaseRepository<PropertyClass>, IPropertyClassRepository
    {
        public PropertyClassRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPropertyClasses(List<PropertyClass> lstPropertyClass)
        {
            var lstPropertyClassIds = lstPropertyClass.Select(x => x.CrmPropertyClassId).ToList();
            var lstDBPropertyClassIds = _dbContext.PropertyClasses.Where(x => lstPropertyClassIds.Contains(x.CrmPropertyClassId)).Select(x => x.CrmPropertyClassId).ToList();
            lstPropertyClass.RemoveAll(x => lstDBPropertyClassIds.Contains(x.CrmPropertyClassId));
            if (lstPropertyClass.Count > 0)
            {
                await _dbContext.PropertyClasses.UpsertRange(lstPropertyClass).On(x => x.CrmPropertyClassId).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }

        public async override Task<IReadOnlyList<PropertyClass>> ListAllAsync()
        {
            return await _dbContext.PropertyClasses
                                   .Include(x => x.PropertyType)
                                   .ToListAsync();
        }
    }
}
