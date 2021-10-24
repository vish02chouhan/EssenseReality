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
    public class PropertyFeatureGroupingRepository : BaseRepository<PropertyFeatureGrouping>, IPropertyFeatureGroupingRepository
    {
        public PropertyFeatureGroupingRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPropertyFeatureGroupings(List<PropertyFeatureGrouping> lstPropertyFeatureGrouping)
        {
            var lstPropertyFeatureGroupingName = lstPropertyFeatureGrouping.Select(x => x.GroupName).Distinct().ToList();
            var lstDBPropertyFeatureGroupingName = _dbContext.PropertyFeatureGroupings.Where(x => lstPropertyFeatureGroupingName.Contains(x.GroupName)).Select(x => x.GroupName).Distinct().ToList();
            lstPropertyFeatureGrouping.RemoveAll(x => lstDBPropertyFeatureGroupingName.Contains(x.GroupName));

            if (lstPropertyFeatureGrouping.Count > 0)
            {
                await _dbContext.PropertyFeatureGroupings.UpsertRange(lstPropertyFeatureGrouping).On(x => x.GroupName).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
