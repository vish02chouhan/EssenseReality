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
    public class GeolocationRepository //: BaseRepository<Geolocation>, IGeolocationRepository
    {
        //public GeolocationRepository(EssenseRealityContext dbContext) : base(dbContext)
        //{
        //}

        //public async Task UpsertGeolocations(IList<Geolocation> lstGeolocation)
        //{
        //    await _dbContext.Geolocations.UpsertRange(lstGeolocation).On(x => x.Latitude).RunAsync();
        //    await _dbContext.SaveChangesAsync();
        //}
    }
}
