using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssenceRealty.Domain.ViewModels;

namespace EssenceRealty.Repository.Repositories
{
    public class EnquiryRepository : BaseRepository<Enquiry>, IEnquiryRepository
    {
        public EnquiryRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {

        }

        public async Task<(IEnumerable<Enquiry>, int)> SearchAsync(EnquirySearchRequest enquirySearchRequestViewModel, int page, int size)
        {
            IQueryable<Enquiry> query = _dbContext.Enquiries;

            if (enquirySearchRequestViewModel.EnquiryType != null)
            {
                query = query.Where(x => enquirySearchRequestViewModel.EnquiryType.Contains(x.EnquiryType));
            }

            if (enquirySearchRequestViewModel.EnquiryDate != null)
            {
                query = query.Where(x => x.EnquiryDate.Date == enquirySearchRequestViewModel.EnquiryDate.Value.Date);
            }


            var dataCount = await query.CountAsync();
            var actualData = await query.Skip((page - 1) * size).Take(size)
                       .ToListAsync();

            return (actualData, dataCount);
        }
    }
}
