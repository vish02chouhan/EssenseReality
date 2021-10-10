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
            //var lstUpdatedGeolocations = _dbContext.Geolocations.ToList();
            //var lstUpdatedAddresses = _dbContext.Addresses.ToList();
            //foreach (var item in lstProperty)
            //{
            //    item.GeolocationId = lstUpdatedGeolocations.Where(x => x.Latitude == item.Geolocation.Latitude && x.Longitude == item.Geolocation.Longitude).First().Id;
            //    item.AddressId = lstUpdatedAddresses.Where(x => x.StreetNumber == item.Address.StreetNumber && x.Street == item.Address.Street 
            //    && x.Level == item.Address.Level && x.UnitNumber == item.Address.UnitNumber).First().Id;
            //}
            var lstUpdatedSuburbs = _dbContext.Suburbs.ToList();
            var lstUpdatedCountries = _dbContext.Countries.ToList();
            foreach (var item in lstProperty)
            {
                item.CountryId = lstUpdatedCountries.Where(x => x.CrmCountryId == item.CountryId).First().Id;
                item.SuburbId = lstUpdatedSuburbs.Where(x => x.CrmSuburbId == item.SuburbId).First().Id;
            }
            await _dbContext.Properties.UpsertRange(lstProperty).On(x => x.CrmPropertyId).RunAsync();
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Property>> GelAll()
        {
          return await  _dbContext.Properties
                       .Include(x => x.Photo)
                       .Include(x => x.Country)
                       .Include(x => x.Suburb)
                       .Include(x => x.ContactStaff).ThenInclude(y=>y.PhoneNumber)
                       .Include(x=> x.PropertyType).ThenInclude(y=>y.PropertyClass)
                       .Include(x => x.PropertyFeature).ToListAsync();
        }

        public async Task<Property> Add(Property property)
        {
            await _dbContext.Properties.AddAsync(property);    
            
            return property;
        }

        //public async Task<Property> Update(Property property)
        //{

        //    await _dbContext.Properties.Update(property);

        //    return property;
        //}
    }
}
