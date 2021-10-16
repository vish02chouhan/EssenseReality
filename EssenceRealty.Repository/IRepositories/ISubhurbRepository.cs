using EssenceRealty.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EssenceRealty.Repository.IRepositories
{
    public interface ISubhurbRepository : IAsyncRepository<Suburb>
    {
        Task UpsertSubhurbs(List<Suburb> lstSubhurb);
    }
}
