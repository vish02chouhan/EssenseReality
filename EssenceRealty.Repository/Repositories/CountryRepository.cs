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
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertCountrys(IList<Country> lstCountry)
        {
            await _dbContext.Countries.UpsertRange(lstCountry).On(x => x.CrmCountryId).RunAsync();
            await _dbContext.SaveChangesAsync();

        }
    }
}
