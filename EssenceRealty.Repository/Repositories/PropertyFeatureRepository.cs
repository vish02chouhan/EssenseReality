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
    public class PropertyFeatureRepository : BaseRepository<PropertyFeature>, IPropertyFeatureRepository
    {
        public PropertyFeatureRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPropertyFeatures(List<PropertyFeature> lstPropertyFeature)
        {
            var lstPropertyFeatureNames = lstPropertyFeature.Select(x => x.Name).Distinct().ToList();
            var lstDBPropertyFeatureNames = _dbContext.PropertyFeatures.Where(x => lstPropertyFeatureNames.Contains(x.Name)).Select(x => x.Name).Distinct().ToList();
            lstPropertyFeature.RemoveAll(x => lstDBPropertyFeatureNames.Contains(x.Name));

            if (lstPropertyFeature.Count > 0)
            {
                var lstPropertyFeatureGroupingNames = lstPropertyFeature.Select(x => x.PropertyFeatureGrouping.GroupName).Distinct().ToList();

                var lstDBPropertyFeatureGroupingDetails = _dbContext.PropertyFeatureGroupings.Where(x => lstPropertyFeatureGroupingNames.Contains(x.GroupName)).Select(x => new { Id = x.Id, GroupName = x.GroupName }).Distinct().ToList();

                foreach (var item in lstPropertyFeature)
                {
                    item.PropertyFeatureGroupingId = lstDBPropertyFeatureGroupingDetails.Where(x => x.GroupName == item.PropertyFeatureGrouping.GroupName).First().Id;
                }

                await _dbContext.PropertyFeatures.UpsertRange(lstPropertyFeature).On(x => x.Name).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
