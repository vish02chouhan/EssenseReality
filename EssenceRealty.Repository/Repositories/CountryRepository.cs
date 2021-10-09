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

        public async Task UpsertCountrys(List<Country> lstCountry)
        {
            var lstCountryIds = lstCountry.Select(x => x.CrmCountryId).Distinct().ToList();
            var lstDBCrmCountryIds = _dbContext.Countries.Where(x => lstCountryIds.Contains(x.CrmCountryId)).Select(x => x.CrmCountryId).Distinct().ToList();
            lstCountry.RemoveAll(x => lstDBCrmCountryIds.Contains(x.CrmCountryId));
            if (lstCountry.Count > 0)
            {
                await _dbContext.Countries.UpsertRange(lstCountry).On(x => x.CrmCountryId).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
