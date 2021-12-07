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
    public class ContactStaffRepository : BaseRepository<ContactStaff>, IContactStaffRepository
    {
        public ContactStaffRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertContactStaffs(List<ContactStaff> lstContactStaff)
        {
            //getting id keys for contact staff returned by CRM
            var lstContactStaffId = lstContactStaff.Select(x => x.CrmContactStaffId).Distinct().ToList();

            //getting contact staff id from db which already exists in above list
            var lstDBCrmContactStaffId = _dbContext.ContactStaffs.Where(x => lstContactStaffId.Contains(x.CrmContactStaffId)).Select(x => x.CrmContactStaffId).Distinct().ToList();

            //remove all contact staff which exists in both db and vault
            lstContactStaff.RemoveAll(x => lstDBCrmContactStaffId.Contains(x.CrmContactStaffId));

            //lstContactStaff now only contains new contact staff

            if (lstContactStaff.Count > 0)
            {
                await _dbContext.ContactStaffs.UpsertRange(lstContactStaff).On(x => x.CrmContactStaffId).RunAsync();

                await _dbContext.SaveChangesAsync();
            }
        }

        public override async Task<ContactStaff> GetByIdAsync(int id)
        {
            var data = await _dbContext.ContactStaffs
                                       .Where(x => x.Id == id)
                                       .Include(x=>x.PhoneNumbers)
                                       .SingleOrDefaultAsync();

            return data;
              
        }

        public async override Task<IReadOnlyList<ContactStaff>> ListAllAsync()
        {
            return await _dbContext.ContactStaffs
                                       .Include(x => x.PhoneNumbers)
                                   .ToListAsync();
        }
    }
}
