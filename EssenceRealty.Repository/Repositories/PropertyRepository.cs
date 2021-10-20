using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }
        public async Task UpsertPropertys(List<Property> lstProperty)
        {
            var lstPropertyIds = lstProperty.Select(x => x.CrmPropertyId).ToList();
            var lstDBPropertyDetails = _dbContext.Properties.Where(x => lstPropertyIds.Contains(x.CrmPropertyId))
                                    .Select(x => new { CrmPropertyId = x.CrmPropertyId, Modified = x.Modified, IsAdminUpdated = x.IsAdminUpdated }).ToList();
            lstProperty.RemoveAll(x => lstDBPropertyDetails.Exists(y => x.CrmPropertyId == y.CrmPropertyId && x.Modified == y.Modified));

            var lstSuburbIds = lstProperty.Select(x => x.SuburbId).Distinct().ToList();
            var lstDBSuburbDetails = _dbContext.Suburbs.Where(x => lstSuburbIds.Contains(x.CrmSuburbId)).Select(x => new { Id = x.Id, CrmSuburbId = x.CrmSuburbId }).Distinct().ToList();

            var lstCountryIds = lstProperty.Select(x => x.CountryId).Distinct().ToList();
            var lstDBCountryDetails = _dbContext.Countries.Where(x => lstCountryIds.Contains(x.CrmCountryId)).Select(x => new { Id = x.Id, CrmCountryId = x.CrmCountryId }).Distinct().ToList();

            var lstPropertyTypeIds = lstProperty.Select(x => x.PropertyTypeId).Distinct().ToList();
            var lstDBPropertyTypeDetails = _dbContext.PropertyTypes.Where(x => lstPropertyTypeIds.Contains(x.CrmPropertyTypeId)).Select(x => new { Id = x.Id, CrmPropertyTypeId = x.CrmPropertyTypeId }).Distinct().ToList();

            foreach (var item in lstProperty)
            {
                item.CountryId = lstDBCountryDetails.Where(x => x.CrmCountryId == item.CountryId).First().Id;
                item.SuburbId = lstDBSuburbDetails.Where(x => x.CrmSuburbId == item.SuburbId).First().Id;
                item.PropertyTypeId = lstDBPropertyTypeDetails.Where(x => x.CrmPropertyTypeId == item.PropertyTypeId).First().Id;
            }

            var propertyNeedsApprovals = lstProperty.FindAll(x => lstDBPropertyDetails.Exists(y => x.CrmPropertyId == y.CrmPropertyId && y.IsAdminUpdated == true));

            lstProperty.RemoveAll(x => lstDBPropertyDetails.Exists(y => x.CrmPropertyId == y.CrmPropertyId && y.IsAdminUpdated == true));

            if (propertyNeedsApprovals.Count > 0)
            {
                var lstPropertyNeedsApprovalsIds = propertyNeedsApprovals.Select(x => x.CrmPropertyId).ToList();

                var lstDBEssenceObjectRequiredApproval = _dbContext.EssenceObjectRequiredApprovals.Where(x => lstPropertyNeedsApprovalsIds.Contains(x.CrmPropertyId))
                    .Select(x => new { CrmPropertyId = x.CrmPropertyId, EssenceObjectRequiredApprovalStatus = x.EssenceObjectRequiredApprovalStatus }).ToList();

                foreach (var item in propertyNeedsApprovals)
                {
                    if (lstDBEssenceObjectRequiredApproval.Exists(x => item.CrmPropertyId == x.CrmPropertyId && x.EssenceObjectRequiredApprovalStatus == EssenceObjectRequiredApprovalStatus.Pending))
                    {
                        await _dbContext.EssenceObjectRequiredApprovals.Upsert(GetEssenceObject(item)).On(x => x.CrmPropertyId).RunAsync();
                    }
                    else
                    {
                        await _dbContext.EssenceObjectRequiredApprovals.AddAsync(GetEssenceObject(item));
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
            if (lstProperty.Count > 0)
            {
                await _dbContext.Properties.UpsertRange(lstProperty).On(x => x.CrmPropertyId).RunAsync();
            }
        }
        public EssenceObjectRequiredApproval GetEssenceObject(Property item)
        {
            return new()
            {
                CrmPropertyId = item.CrmPropertyId,
                EssenceObjectRequiredApprovalStatus = EssenceObjectRequiredApprovalStatus.Pending,
                EssenceObjectTypes = EssenceObjectTypes.Property,
                Id = 0,
                JsonObject = JsonSerializer.Serialize(item),
                CreatedBy = ERConstants.PROPERTY_PROCESSOR,
                CreatedDate = System.DateTime.Now,
                ModifiedDate = System.DateTime.Now,
                ModifieldBy = ERConstants.PROPERTY_PROCESSOR
            };
        }

        public async Task<IEnumerable<Property>> GelAll()
        {
          return await  _dbContext.Properties
                       .Include(x => x.Photo)
                       .Include(x => x.Country)
                       .Include(x => x.Suburb)
                       .Include(x => x.PropertyContactStaffs).ThenInclude(y => y.ContactStaff).ThenInclude(z => z.PhoneNumbers)
                       .Include(x => x.PropertyType).ThenInclude(y => y.PropertyClass)
                       .Include(x => x.PropertyFeature)
                       .ToListAsync();
        }

        public async Task<Property> Add(Property property)
        {
            await _dbContext.Properties.AddAsync(property);    
            
            return property;
        }

        public override async Task<Property> GetByIdAsync(int id)
        {
            var data = await _dbContext.Properties.Where(x => x.Id == id)
                       .Include(x => x.Photo)
                       .Include(x => x.Country)
                       .Include(x => x.Suburb)
                       .Include(x => x.PropertyContactStaffs).ThenInclude(y => y.ContactStaff).ThenInclude(z => z.PhoneNumbers)
                       .Include(x => x.PropertyType).ThenInclude(y => y.PropertyClass)
                       .Include(x => x.PropertyFeature).SingleOrDefaultAsync();

            if(data != null)
            {
                data.ContactStaff = await _dbContext.PropertyContactStaffs
                                    .Where(x => x.PropertyId == id)
                                    .Include(x => x.ContactStaff).ThenInclude(y => y.PhoneNumbers)
                                    .Select(x => x.ContactStaff).ToListAsync();
            }


            return data;
        }
    }
}
