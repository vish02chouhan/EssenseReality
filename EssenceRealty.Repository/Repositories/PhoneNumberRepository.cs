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
    public class PhoneNumberRepository : BaseRepository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPhoneNumbers(IList<PhoneNumber> lstPhoneNumber)
        {
            var lstUpdatedContactStaffs = _dbContext.ContactStaffs.ToList();
            foreach (var item in lstPhoneNumber)
            {
                int id = item.ContactStaffId;
                item.ContactStaffId = lstUpdatedContactStaffs.Where(x => x.CrmContactStaffId == id).First().Id;
            }

            await _dbContext.PhoneNumbers.UpsertRange(lstPhoneNumber).On(x => x.Number).RunAsync();
            await _dbContext.SaveChangesAsync();

        }
    }
}
