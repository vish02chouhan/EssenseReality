using EssenceRealty.Domain.Models;
using EssenceRealty.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EssenceRealty.Repository.IRepositories
{
    public interface IEnquiryRepository : IAsyncRepository<Enquiry>, IAsyncSearch<Enquiry, int, EnquirySearchRequest>
    {
        
    }
}
