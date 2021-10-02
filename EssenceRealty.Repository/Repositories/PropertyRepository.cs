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
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPropertys(IList<Property> lstProperty)
        {
            var lstUpdatedGeolocations = _dbContext.Geolocations.ToList();
            var lstUpdatedAddresses = _dbContext.Addresses.ToList();
            foreach (var item in lstProperty)
            {
                item.GeolocationId = lstUpdatedGeolocations.Where(x => x.Latitude == item.Geolocation.Latitude && x.Longitude == item.Geolocation.Longitude).First().Id;
                item.AddressId = lstUpdatedAddresses.Where(x => x.StreetNumber == item.Address.StreetNumber && x.Street == item.Address.Street 
                && x.Level == item.Address.Level && x.UnitNumber == item.Address.UnitNumber).First().Id;
            }
            await _dbContext.Properties.UpsertRange(lstProperty).On(x => x.CrmPropertyId).RunAsync();
            await _dbContext.SaveChangesAsync();

        }
    }
}
