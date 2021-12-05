using EssenceRealty.Domain.Models;
using EssenceRealty.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EssenceRealty.Repository.IRepositories
{
    public interface IPropertyRepository:IAsyncRepository<Property>, IAsyncSearch<Property, PropertySearchRequest>
    {
        Task UpsertProperties(List<Property> lstProperty);
        Task<IEnumerable<Property>> GelAll();
        Task<Property> UpdateProperty(Property objProperty, bool isAdmin = false);
        Task<Property> GetPropertyByCRMID(int? crmPropertyId);
        Task UpdatePropertyNotExistsInCRM(List<int?> lstVaultPropertyId);
    }
}
