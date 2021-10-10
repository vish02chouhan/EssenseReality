using EssenseReality.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EssenceRealty.Repository.IRepositories
{
    public interface IPropertyRepository
    {
        Task UpsertPropertys(IList<Property> lstProperty);
        Task<IEnumerable<Property>> GelAll();
    }
}
