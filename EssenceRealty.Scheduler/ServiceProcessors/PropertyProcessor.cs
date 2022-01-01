using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssenceRealty.Domain.Enums;
using System.Reflection;

namespace EssenceRealty.Scheduler.ServiceProcessors
{
    public class PropertyProcessor:IProcessEssence
    {
        private readonly IServiceProvider serviceProvider;
        public PropertyProcessor()
        {

        }
        PropertyProcessor(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task ProcessJsonData(CrmEssenceLog objCrmEssenceLog)
        {
            var items = JArray.Parse(objCrmEssenceLog.JsonObjectBatch);
            try
            {
                if (items.HasValues)
                {
                    List<Property> lstProperty = new ();
                    List<Photo> lstPhoto = new ();
                    List<Country> lstCountry = new ();
                    List<ContactStaff> lstContactStaff = new ();
                    List<PhoneNumber> lstPhoneNumbers = new ();


                    var suburbArray = new JArray();
                    suburbArray.Add(items.Children().Select(x => x["address"]["suburb"]));
                    SuburbsProcessor suburbProcessor = new(this.serviceProvider);
                    var lstSubHurbs = suburbProcessor.ExtractSuburbStateData(suburbArray);

                    var propertTypeArray = new JArray();
                    propertTypeArray.Add(items.Children().Select(x => x["type"]));
                    PropertyTypeProcessor propertTypeProcessor = new();
                    var lstpropertyType = propertTypeProcessor.ExtractPropertyTypeData(propertTypeArray);
                    var lstpropertClass = propertTypeProcessor.ExtractPropertyClassData(lstpropertyType);

                    ContactsProcessor contactStaffProcessor = new(this.serviceProvider);

                    foreach (var item in items)
                    {
                        List<Photo> lstPropertyPhotos = new();
                        List<ContactStaff> lstPropertyContactStaffs = new();

                        dynamic data = JsonConvert.DeserializeObject(item.ToString());
                        if (data != null && data.address != null && data.address.country != null)
                        {
                            lstCountry.Add(ExtractCountryData(data.address.country));
                        }
                        if (data != null && data.photos != null)
                        {
                            foreach (var photo in data.photos)
                            {
                                lstPropertyPhotos.Add(ExtractPhotoData(photo, checkNullForInt(data.id?.ToString())));
                            }
                        }
                        if (data != null && data.contactStaff != null)
                        {
                            foreach (var contactStaff in data.contactStaff)
                            {
                                if (!lstPropertyContactStaffs.Exists(x => x.CrmContactStaffId.ToString() == contactStaff.id.ToString()))
                                {
                                    List<PhoneNumber> lstPhnNumber = new();
                                    foreach (var phoneNumber in contactStaff.phoneNumbers)
                                    {
                                        lstPhnNumber.Add(contactStaffProcessor.ExtractPhoneNumberData(phoneNumber, Convert.ToInt32(contactStaff.id)));
                                    }
                                    ContactStaff objContactStaff = contactStaffProcessor.ExtractContactStaffData(contactStaff);
                                    objContactStaff.PhoneNumbers = lstPhnNumber;
                                    lstPropertyContactStaffs.Add(objContactStaff);
                                    lstPhoneNumbers.AddRange(lstPhnNumber);
                                }
                            }
                        }
                        Property objProperty = new();
                        objProperty = ExtractPropertyData(item, objCrmEssenceLog.EndPointUrl);
                        objProperty.Country = lstCountry.Find(x => x.CrmCountryId == objProperty.CountryId);
                        objProperty.Photo = lstPropertyPhotos;
                        objProperty.Suburb = lstSubHurbs.Find(x => x.CrmSuburbId == objProperty.SuburbId);
                        objProperty.PropertyType = lstpropertyType.Find(x => x.CrmPropertyTypeId == objProperty.PropertyTypeId);
                        objProperty.ContactStaff = lstPropertyContactStaffs;
                        lstProperty.Add(objProperty);
                        lstPhoto.AddRange(lstPropertyPhotos);
                        lstContactStaff.AddRange(lstPropertyContactStaffs);
                    }
                    
                    using var scope = serviceProvider.CreateScope();
                    await suburbProcessor.UpsertStateData(scope, lstSubHurbs);
                    await suburbProcessor.UpsertSubhurbData(scope, lstSubHurbs);

                    PropertyClassProcessor propertyClassProcessor = new(this.serviceProvider);
                    await propertyClassProcessor.UpsertPropertyClassData(scope, lstpropertClass);
                    
                    await propertTypeProcessor.UpsertPropertyTypeData(scope, lstpropertyType);

                    await UpsertCountryData(scope, lstCountry);
                    await UpsertPropertyData(scope, lstProperty);
                    await UpsertPhotoData(scope, lstPhoto);
                    await contactStaffProcessor.UpsertContactStaffData(scope, lstContactStaff);
                    await contactStaffProcessor.UpsertPhoneNumberData(scope, lstPhoneNumbers);
                    await UpsertPropertyContactStaffData(scope, lstProperty);
                    //return lstProperty.Select(x => x.CrmPropertyId).ToList();
                }
                //return new List<int?>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private Property ExtractPropertyData(JToken item, string endPointURL)
        {
            try
            {
                JsonProcessor<Property> objJsonProcessor = new();
                Property objProperty = (Property)objJsonProcessor.ExtractData<Property>(item);
                objProperty.CrmPropertyId = objProperty.Id;
                objProperty.Id = 0;
                dynamic data = JsonConvert.DeserializeObject(item.ToString());
                objProperty.CountryId = checkNullForInt(data.address.country.id?.ToString());
                objProperty.SuburbId = checkNullForInt(data.address.suburb.id?.ToString());
                objProperty.FloorAreaUnit = data.floorArea.units?.ToString();
                objProperty.FloorAreaValue = checkNullForInt(data.floorArea.value?.ToString());
                objProperty.IsActive = true;
                objProperty.PropertyTypeId = checkNullForInt(data.type.id?.ToString());
                objProperty.PropertyTranasctionType = CalculateStatus(endPointURL, data.status?.ToString());
                objProperty.CreatedBy = ERConstants.PROPERTY_PROCESSOR;
                objProperty.ModifieldBy = ERConstants.PROPERTY_PROCESSOR;
                return objProperty;
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public string CalculateStatus(string endPointURL, string status)
        {
            if (endPointURL.Contains("/sale"))
            {
                return status.ToString().ToUpper() == PropertyStatus.UnConditional.ToString().ToUpper()
                    ? PropertTransactionType.Sold.ToString()
                    : PropertTransactionType.Sale.ToString();

            }

            else if ((endPointURL.Contains("/lease")))
            {
                return status.ToString().ToUpper() == PropertyStatus.Appraisal.ToString().ToUpper() ? PropertTransactionType.Leased.ToString()
                    : PropertTransactionType.Lease.ToString();

            }

            return string.Empty;         
        }

        private Country ExtractCountryData(JToken address)
        {
            Country objCountry = JsonConvert.DeserializeObject<Country>(address.ToString());
            objCountry.CrmCountryId = objCountry.Id;
            objCountry.Id = 0;
            objCountry.CreatedBy = ERConstants.PROPERTY_PROCESSOR;
            objCountry.ModifieldBy = ERConstants.PROPERTY_PROCESSOR;
            return objCountry;
        }
        private Photo ExtractPhotoData(JToken photo, int proprtyId)
        {
            Photo objPhoto = JsonConvert.DeserializeObject<Photo>(photo.ToString());
            objPhoto.CrmPhotoId = objPhoto.Id;
            objPhoto.Id = 0;
            objPhoto.PropertyId = proprtyId;
            objPhoto.Thumb1024 = photo["thumbnails"]["thumb_1024"]?.ToString();
            objPhoto.Thumb180 = photo["thumbnails"]["thumb_180"]?.ToString();
            objPhoto.CreatedBy = ERConstants.PROPERTY_PROCESSOR;
            objPhoto.ModifieldBy = ERConstants.PROPERTY_PROCESSOR;
            return objPhoto;
        }
        private async Task UpsertCountryData(IServiceScope scope, List<Country> lstCountry)
        {
            var countryRepo = scope.ServiceProvider.GetRequiredService<ICountryRepository>();
            await countryRepo.UpsertCountrys(lstCountry.Select(x => x)
                        .Where(x => x != null && x.CrmCountryId > 0).ToList()
                        .GroupBy(elem => elem.CrmCountryId)
                        .Select(group => group.First()).ToList());
        }
        private async Task UpsertPropertyData(IServiceScope scope, List<Property> lstProperty)
        {
            var propertyRepo = scope.ServiceProvider.GetRequiredService<IPropertyRepository>();
            await propertyRepo.UpsertProperties(lstProperty.Select(x => x)
                        .Where(x => x != null && x.CrmPropertyId > 0).ToList()
                        .GroupBy(elem => elem.CrmPropertyId)
                        .Select(group => group.First()).ToList());
        }
        private async Task UpsertPhotoData(IServiceScope scope, List<Photo> lstPhoto)
        {
            var photoRepo = scope.ServiceProvider.GetRequiredService<IPhotoRepository>();
            await photoRepo.UpsertPhotos(lstPhoto.Select(x => x)
                        .Where(x => x != null && x.CrmPhotoId > 0).ToList()
                        .GroupBy(elem => elem.CrmPhotoId)
                        .Select(group => group.First()).ToList());
        }
        private async Task UpsertPropertyContactStaffData(IServiceScope scope, List<Property> lstProperty)
        {
            var propertyContactStaffRepo = scope.ServiceProvider.GetRequiredService<IPropertyContactStaffRepository>();
            await propertyContactStaffRepo.UpsertPropertyContactStaffs(lstProperty);
        }
        private int checkNullForInt(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return 0;
                }
                return Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private double checkNullForDouble(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return Convert.ToDouble(value);
        }
        public async Task UpdatePropertyNotExistsInCRM(IServiceProvider serviceProvider, List<int?> lstVaultPropertyId)
        {

            using var scope = serviceProvider.CreateScope();
            var propertyRepo = scope.ServiceProvider.GetRequiredService<IPropertyRepository>();
            await propertyRepo.UpdatePropertyNotExistsInCRM(lstVaultPropertyId);
        }
    }
}
