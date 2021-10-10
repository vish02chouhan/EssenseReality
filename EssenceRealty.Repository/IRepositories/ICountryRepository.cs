using EssenseReality.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EssenceRealty.Repository.IRepositories
{
    public interface ICountryRepository :IAsyncRepository<Country>
    {
        Task UpsertCountrys(List<Country> lstCountry);
    }
}
