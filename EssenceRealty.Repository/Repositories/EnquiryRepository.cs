using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class EnquiryRepository : BaseRepository<Enquiry>, IEnquiryRepository
    {
        public EnquiryRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

    }
}
