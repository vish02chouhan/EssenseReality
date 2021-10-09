using EssenceRealty.Repository.IRepositories;
using EssenseReality.Data;
using EssenseReality.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }
        public async Task UpsertPropertys(List<Property> lstProperty)
        {
            var lstPropertyIds = lstProperty.Select(x => x.CrmPropertyId).ToList();
            var lstDBPropertyDetails = _dbContext.Properties.Where(x => lstPropertyIds.Contains(x.CrmPropertyId))
                                    .Select(x => new { CrmPropertyId = x.CrmPropertyId, Modified = x.Modified, IsAdminUpdated = x.IsAdminUpdated }).ToList();
            lstProperty.RemoveAll(x => lstDBPropertyDetails.Exists(y => x.CrmPropertyId == y.CrmPropertyId && x.Modified == y.Modified));

            var lstSuburbIds = lstProperty.Select(x => x.SuburbId).Distinct().ToList();
            var lstDBSuburbDetails = _dbContext.Suburbs.Where(x => lstSuburbIds.Contains(x.CrmSuburbId)).Select(x => new { Id = x.Id, CrmSuburbId = x.CrmSuburbId }).Distinct().ToList();

            var lstCountryIds = lstProperty.Select(x => x.CountryId).Distinct().ToList();
            var lstDBCountryDetails = _dbContext.Countries.Where(x => lstCountryIds.Contains(x.CrmCountryId)).Select(x => new { Id = x.Id, CrmCountryId = x.CrmCountryId }).Distinct().ToList();

            var lstPropertyTypeIds = lstProperty.Select(x => x.PropertyTypeId).Distinct().ToList();
            var lstDBPropertyTypeDetails = _dbContext.PropertyTypes.Where(x => lstPropertyTypeIds.Contains(x.CrmPropertyTypeId)).Select(x => new { Id = x.Id, CrmPropertyTypeId = x.CrmPropertyTypeId }).Distinct().ToList();

            foreach (var item in lstProperty)
            {
                item.CountryId = lstDBCountryDetails.Where(x => x.CrmCountryId == item.CountryId).First().Id;
                item.SuburbId = lstDBSuburbDetails.Where(x => x.CrmSuburbId == item.SuburbId).First().Id;
                item.PropertyTypeId = lstDBPropertyTypeDetails.Where(x => x.CrmPropertyTypeId == item.PropertyTypeId).First().Id;
            }

            var propertyNeedsApprovals = lstProperty.FindAll(x => lstDBPropertyDetails.Exists(y => x.CrmPropertyId == y.CrmPropertyId && y.IsAdminUpdated == true));
            
            lstProperty.RemoveAll(x => lstDBPropertyDetails.Exists(y => x.CrmPropertyId == y.CrmPropertyId && y.IsAdminUpdated == true));

            if (propertyNeedsApprovals.Count > 0)
            {
                var jsn = JsonSerializer.Serialize(propertyNeedsApprovals);
                //await _dbContext.EssenceObjectRequiredApprovals.UpsertRange(propertyNeedsApprovals).On(x => x.).RunAsync();
                await _dbContext.SaveChangesAsync();
            }

            if (lstProperty.Count > 0)
            {
                await _dbContext.Properties.UpsertRange(lstProperty).On(x => x.CrmPropertyId).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
