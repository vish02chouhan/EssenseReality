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
    public class AddressRepository //: BaseRepository<Address>, IAddressRepository
    {
        //public AddressRepository(EssenseRealityContext dbContext) : base(dbContext)
        //{
        //}

        //public async Task UpsertAddresss(IList<Address> lstAddress)
        //{
        //    var lstUpdatedSuburbs = _dbContext.Suburbs.ToList();
        //    var lstUpdatedCountries = _dbContext.Countries.ToList();
        //    foreach (var item in lstAddress)
        //    {
        //        int coutryid = item.CountryId;
        //        int suburbid = item.SuburbId;
        //        item.CountryId = lstUpdatedCountries.Where(x => x.CrmCountryId == coutryid).First().Id;
        //        item.SuburbId = lstUpdatedSuburbs.Where(x => x.CrmSuburbId == suburbid).First().Id;
        //    }
        //    await _dbContext.Addresses.UpsertRange(lstAddress).On(x => x.StreetNumber).RunAsync();
        //    await _dbContext.SaveChangesAsync();

        //}
    }
}
