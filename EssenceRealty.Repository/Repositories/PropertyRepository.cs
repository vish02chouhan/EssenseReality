using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EssenceRealty.Domain.ViewModels;

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
          var data = await  _dbContext.Properties
                       .Include(x => x.Photo)
                       .Include(x => x.Country)
                       .Include(x => x.Suburb)
                       .Include(x => x.PropertyContactStaffs).ThenInclude(y => y.ContactStaff).ThenInclude(z => z.PhoneNumbers)
                       .Include(x => x.PropertyType).ThenInclude(y => y.PropertyClass)
                       .Include(x => x.PropertyFeatureProperties).ThenInclude(y => y.PropertyFeature).ThenInclude(z => z.PropertyFeatureGrouping)
                       .ToListAsync();
            foreach (var item in data)
            {
                //item.ContactStaff = await _dbContext.PropertyContactStaffs
                //                  .Where(x => x.PropertyId == item.Id)
                //                  .Include(x => x.ContactStaff).ThenInclude(y => y.PhoneNumbers)
                //                  .Select(x => x.ContactStaff).ToListAsync();
                item.ContactStaff = item.PropertyContactStaffs.Select(x => x.ContactStaff).Distinct().ToList();
                item.PropertyFeatureGrouping = item.PropertyFeatureProperties.Select(x => x.PropertyFeature.PropertyFeatureGrouping).Distinct().ToList();

            }

            return data;
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
                       .Include(x => x.PropertyFeatureProperties).ThenInclude(y => y.PropertyFeature).ThenInclude(z => z.PropertyFeatureGrouping)
                       .SingleOrDefaultAsync();

            if (data != null)
            {
                data.ContactStaff = data.PropertyContactStaffs.Select(x => x.ContactStaff).Distinct().ToList();
                data.PropertyFeatureGrouping = data.PropertyFeatureProperties.Select(x => x.PropertyFeature.PropertyFeatureGrouping).Distinct().ToList();
            }

            return data;
        }

        public async Task<IEnumerable<Property>> SearchAsync(PropertySearchRequest propertySearchRequestViewModel)
        {
            IQueryable<Property> query = _dbContext.Properties;

            if (propertySearchRequestViewModel.PropertyTypeId != null)
            {
               query = _dbContext.Properties.Where(x => propertySearchRequestViewModel.PropertyTypeId.Contains(x.PropertyTypeId));
            }

            if (propertySearchRequestViewModel.BedsMin != null && propertySearchRequestViewModel.BedsMax != null)
            {
                query = query.Where(x => x.Bed >= propertySearchRequestViewModel.BedsMin && x.Bed <= propertySearchRequestViewModel.BedsMax);
            }

            if (propertySearchRequestViewModel.BedsMin != null && propertySearchRequestViewModel.BedsMax == null)
            {
                query = query.Where(x => x.Bed >= propertySearchRequestViewModel.BedsMin);
            }

            if (propertySearchRequestViewModel.BedsMin == null && propertySearchRequestViewModel.BedsMax != null)
            {
                query = query.Where(x => x.Bed <= propertySearchRequestViewModel.BedsMin);
            }
            //Price check
            if (propertySearchRequestViewModel.PriceMin != null && propertySearchRequestViewModel.PriceMax != null)
            {
                query = query.Where(x => x.SearchPrice >= propertySearchRequestViewModel.PriceMin && x.SearchPrice <= propertySearchRequestViewModel.PriceMax);
            }

            if (propertySearchRequestViewModel.PriceMin != null && propertySearchRequestViewModel.PriceMax == null)
            {
                query = query.Where(x => x.SearchPrice >= propertySearchRequestViewModel.PriceMin);
            }

            if (propertySearchRequestViewModel.PriceMin == null && propertySearchRequestViewModel.PriceMax != null)
            {
                query = query.Where(x => x.SearchPrice <= propertySearchRequestViewModel.PriceMax);
            }

           var data = await query.Include(x => x.Photo)
                       .Include(x => x.Country)
                       .Include(x => x.Suburb)                     
                       .Include(x => x.PropertyType).ThenInclude(y => y.PropertyClass)
                       .Include(x => x.PropertyContactStaffs).ThenInclude(y => y.ContactStaff).ThenInclude(z => z.PhoneNumbers)
                       .Include(x => x.PropertyFeatureProperties).ThenInclude(y => y.PropertyFeature).ThenInclude(z => z.PropertyFeatureGrouping)
                       .ToListAsync();

            foreach (var item in data)
            {
                //item.ContactStaff = await _dbContext.PropertyContactStaffs
                //                  .Where(x => x.PropertyId == item.Id)
                //                  .Include(x => x.ContactStaff).ThenInclude(y => y.PhoneNumbers)
                //                  .Select(x => x.ContactStaff).ToListAsync();
                item.ContactStaff = item.PropertyContactStaffs.Select(x => x.ContactStaff).Distinct().ToList();
                item.PropertyFeatureGrouping = item.PropertyFeatureProperties.Select(x => x.PropertyFeature.PropertyFeatureGrouping).Distinct().ToList();

            }

            return data;
        }

        public async Task<Property> UpdateProperty(Property objProperty)
        {

            var lstDBPropertyContactStaff = _dbContext.PropertyContactStaffs.AsNoTracking().Where(x => x.PropertyId == objProperty.Id).ToList();
            List<PropertyContactStaff> lstPropertyContactStaffInserted = GetPropertyContactInsertList(objProperty, lstDBPropertyContactStaff);
            List<PropertyContactStaff> lstPropertyContactStaffDeleted = GetPropertyContactDeleteList(objProperty, lstDBPropertyContactStaff);
            var lstDBPropertyFeatureProperty = _dbContext.PropertyFeatureProperties.AsNoTracking().Where(x => x.PropertyId == objProperty.Id).ToList();
            var lstPropertyFeatures = objProperty.PropertyFeatureGrouping.Select(x => x.PropertyFeature).ToList();
            List<PropertyFeatureProperty> lstPropertyFeaturePropertyInserted = GetPropertyFeaturePropertyInsertList(lstPropertyFeatures, lstDBPropertyFeatureProperty);
            List<PropertyFeatureProperty> lstPropertyFeaturePropertyIDeleted = GetPropertyFeaturePropertyDeleteList(lstPropertyFeatures, lstDBPropertyFeatureProperty);


            
            _dbContext.PropertyContactStaffs.AddRange(lstPropertyContactStaffInserted);
            _dbContext.PropertyContactStaffs.RemoveRange(lstPropertyContactStaffDeleted);
            _dbContext.PropertyFeatureProperties.AddRange(lstPropertyFeaturePropertyInserted);
            _dbContext.PropertyFeatureProperties.RemoveRange(lstPropertyFeaturePropertyIDeleted);
            _dbContext.Entry(objProperty).State = EntityState.Modified;
            _dbContext.Properties.Update(objProperty);
            await _dbContext.SaveChangesAsync();
            return objProperty;
        }
        private List<PropertyContactStaff> GetPropertyContactInsertList(Property objProperty, List<PropertyContactStaff> lstDBPropertyContactStaff)
        {
            List<PropertyContactStaff> lstPropertyContactStaffInserted = new();
            foreach (var item in objProperty.ContactStaff)
            {
                if (lstDBPropertyContactStaff.FindIndex(x => x.ContactStaffId == item.Id) < 0)
                {
                    PropertyContactStaff objPropertyContactStaff = new()
                    {
                        ContactStaffId = item.Id,
                        PropertyId = objProperty.Id
                    };
                    lstPropertyContactStaffInserted.Add(objPropertyContactStaff);
                }
            }
            return lstPropertyContactStaffInserted;
        }
        private List<PropertyContactStaff> GetPropertyContactDeleteList(Property objProperty, List<PropertyContactStaff> lstDBPropertyContactStaff)
        {
            List<PropertyContactStaff> lstPropertyContactStaffDeleted = new();
            foreach (var item in lstDBPropertyContactStaff)
            {
                if (objProperty.ContactStaff.FindIndex(x => x.Id == item.ContactStaffId) < 0)
                {
                    PropertyContactStaff objPropertyContactStaff = new()
                    {
                        ContactStaffId = item.ContactStaffId,
                        PropertyId = objProperty.Id
                    };
                    lstPropertyContactStaffDeleted.Add(objPropertyContactStaff);
                }
            }
            return lstPropertyContactStaffDeleted;
        }
        private List<PropertyFeatureProperty> GetPropertyFeaturePropertyInsertList(List<ICollection<PropertyFeature>> lstPropertyFeatures, List<PropertyFeatureProperty> lstDBPropertyFeatureProperty)
        {
            List<PropertyFeatureProperty> lstPropertyFeaturePropertyInserted = new();
            foreach (var propertyFeatures in lstPropertyFeatures)
            {
                foreach (var item in propertyFeatures)
                {
                    if (lstDBPropertyFeatureProperty.FindIndex(x => x.PropertyFeatureId == item.Id) < 0)
                    {
                        PropertyFeatureProperty objPropertyFeatureProperty = new()
                        {
                            PropertyFeatureId = item.Id,
                            PropertyId = propertyFeatures.FirstOrDefault().Id
                        };
                        lstPropertyFeaturePropertyInserted.Add(objPropertyFeatureProperty);
                    }
                }
            }
            return lstPropertyFeaturePropertyInserted;
        }
        private List<PropertyFeatureProperty> GetPropertyFeaturePropertyDeleteList(List<ICollection<PropertyFeature>> lstPropertyFeatures, List<PropertyFeatureProperty> lstDBPropertyFeatureProperty)
        {
            List<PropertyFeatureProperty> lstPropertyFeaturePropertyIDeleted = new();
            foreach (var item in lstDBPropertyFeatureProperty)
            {
                if(!lstPropertyFeatures.Any(x => x.Any(y => y.Id == item.PropertyFeatureId)))
                {
                    PropertyFeatureProperty objPropertyFeatureProperty = new()
                    {
                        PropertyFeatureId = item.PropertyFeatureId,
                        PropertyId = item.PropertyId
                    };
                    lstPropertyFeaturePropertyIDeleted.Add(objPropertyFeatureProperty);
                }
            }
            return lstPropertyFeaturePropertyIDeleted;
        }
    }
}
