using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class PropertyFeaturePropertyRepository : BaseRepository<PropertyFeatureProperty>, IPropertyFeaturePropertyRepository
    {
        public PropertyFeaturePropertyRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPropertyFeatureProperty(List<PropertyFeature> lstPropertyFeature, int crmPropertyId)
        {
            if (lstPropertyFeature.Count > 0)
            {
                var lstPropertyFeatureName = lstPropertyFeature.Select(x => x.Name).ToList();
                var propertyId = _dbContext.Properties.Where(x => x.CrmPropertyId == crmPropertyId).Select(x => x.Id).FirstOrDefault();
                var lstDBPropertyFeatureDetails = _dbContext.PropertyFeatures.Where(x => lstPropertyFeatureName.Contains(x.Name))
                                        .Select(x => new { Id = x.Id, Name = x.Name }).ToList();

                List<PropertyFeatureProperty> lstPropertyFeatureProperty = new();

                foreach (var item in lstPropertyFeature)
                {
                    PropertyFeatureProperty objPropertyFeatureProperty = new()
                    {
                        PropertyFeatureId = lstDBPropertyFeatureDetails.Where(x => x.Name == item.Name).First().Id,
                        PropertyId = propertyId
                    };
                    var propertyIdExists = _dbContext.PropertyFeatureProperties
                        .Where(x => x.PropertyId == propertyId && x.PropertyFeatureId == objPropertyFeatureProperty.PropertyFeatureId)
                        .Select(x => x.PropertyId).FirstOrDefault();
                    if (propertyIdExists <= 0)
                    {
                        lstPropertyFeatureProperty.Add(objPropertyFeatureProperty);
                    }
                }

                if (lstPropertyFeatureProperty.Count > 0)
                {
                    await _dbContext.PropertyFeatureProperties.UpsertRange(lstPropertyFeatureProperty).On(x => x.PropertyId).RunAsync();
                }
            }
        }
    }
}
