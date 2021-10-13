using EssenceRealty.Repository.IRepositories;
using EssenseReality.Data;
using EssenseReality.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class PropertyContactStaffRepository : BaseRepository<PropertyContactStaff>, IPropertyContactStaffRepository
    {
        public PropertyContactStaffRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPropertyContactStaffs(List<Property> lstProperty)
        {
            var lstPropertyIds = lstProperty.Select(x => x.CrmPropertyId);
            var lstContactIds = lstProperty.SelectMany(x => x.ContactStaff.Select(y => y.CrmContactStaffId));
            var lstPropertyContactStaffDetails = lstProperty.SelectMany(x => x.ContactStaff
                                .Select(y => new { CrmPropertyId = x.CrmPropertyId, CrmContactStaffId = y.CrmContactStaffId }))
                                .GroupBy(x => x).Select(g => g.First()).ToList();

            var lstDBPropertyIds = _dbContext.Properties.Where(x => lstPropertyIds.Contains(x.CrmPropertyId))
                                   .Select(x => new { Id = x.Id, CrmPropertyId = x.CrmPropertyId}).ToList();
            var lstDBContactStaffIds = _dbContext.ContactStaffs.Where(x => lstContactIds.Contains(x.CrmContactStaffId))
                                    .Select(x => new { Id = x.Id, CrmContactStaffId = x.CrmContactStaffId }).ToList();

            List<PropertyContactStaff> lstPropertyContactStaff = new();

            foreach (var item in lstPropertyContactStaffDetails)
            {
                PropertyContactStaff objPropertyContactStaff = new()
                {
                    ContactStaffId = lstDBContactStaffIds.Where(x => x.CrmContactStaffId == item.CrmContactStaffId).First().Id,
                    PropertyId = lstDBPropertyIds.Where(x => x.CrmPropertyId == item.CrmPropertyId).First().Id,
                };
                var propertyIdExists = _dbContext.PropertyContactStaffs
                    .Where(x => x.ContactStaffId == objPropertyContactStaff.ContactStaffId && x.PropertyId == objPropertyContactStaff.PropertyId)
                    .Select(x => x.PropertyId).First();
                if (propertyIdExists <= 0)
                {
                    lstPropertyContactStaff.Add(objPropertyContactStaff);
                }
            }

            if (lstPropertyContactStaff.Count > 0)
            {
                await _dbContext.PropertyContactStaffs.UpsertRange(lstPropertyContactStaff).On(x => x.PropertyId).RunAsync();
            }
        }
    }
}
