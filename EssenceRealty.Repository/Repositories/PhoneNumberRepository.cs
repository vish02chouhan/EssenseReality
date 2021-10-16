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
    public class PhoneNumberRepository : BaseRepository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPhoneNumbers(List<PhoneNumber> lstPhoneNumber)
        {
            var lstPhoneNumberIds = lstPhoneNumber.Select(x => x.Number).Distinct().ToList();
            var lstDBPhoneNumberIds = _dbContext.PhoneNumbers.Where(x => lstPhoneNumberIds.Contains(x.Number)).Select(x => x.Number).Distinct().ToList();
            lstPhoneNumber.RemoveAll(x => lstDBPhoneNumberIds.Contains(x.Number));

            if (lstPhoneNumber.Count > 0)
            {
                var lstContactStaffIds = lstPhoneNumber.Select(x => x.ContactStaffId).Distinct().ToList();
                var lstDBContactStaffDetails = _dbContext.ContactStaffs.Where(x => lstContactStaffIds.Contains(x.CrmContactStaffId)).Select(x => new { Id = x.Id, CrmContactStaffId = x.CrmContactStaffId }).Distinct().ToList();
                foreach (var item in lstPhoneNumber)
                {
                    item.ContactStaffId = lstDBContactStaffDetails.Where(x => x.CrmContactStaffId == item.ContactStaffId).First().Id;
                }

                await _dbContext.PhoneNumbers.UpsertRange(lstPhoneNumber).On(x => x.Number).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
