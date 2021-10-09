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
    public class ContactStaffRepository : BaseRepository<ContactStaff>, IContactStaffRepository
    {
        public ContactStaffRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertContactStaffs(List<ContactStaff> lstContactStaff)
        {
            var lstContactStaffId = lstContactStaff.Select(x => x.CrmContactStaffId).Distinct().ToList();
            var lstDBCrmContactStaffId = _dbContext.ContactStaffs.Where(x => lstContactStaffId.Contains(x.CrmContactStaffId)).Select(x => x.CrmContactStaffId).Distinct().ToList();
            lstContactStaff.RemoveAll(x => lstDBCrmContactStaffId.Contains(x.CrmContactStaffId));

            if (lstContactStaff.Count > 0)
            {
                await _dbContext.ContactStaffs.UpsertRange(lstContactStaff).On(x => x.CrmContactStaffId).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
