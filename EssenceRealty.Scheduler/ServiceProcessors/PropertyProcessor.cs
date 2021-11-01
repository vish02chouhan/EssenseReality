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

namespace EssenceRealty.Scheduler.ServiceProcessors
{
    public class PropertyProcessor
    {
        public async Task ProcessPropertyData(IServiceProvider serviceProvider, JArray items)
        {
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
                    SuburbProcessor suburbProcessor = new();
                    var lstSubHurbs = suburbProcessor.ExtractSuburbStateData(suburbArray);

                    var propertTypeArray = new JArray();
                    propertTypeArray.Add(items.Children().Select(x => x["type"]));
                    PropertyTypeProcessor propertTypeProcessor = new();
                    var lstpropertyType = propertTypeProcessor.ExtractPropertyTypeData(propertTypeArray);
                    var lstpropertClass = propertTypeProcessor.ExtractPropertyClassData(lstpropertyType);

                    ContactStaffProcessor contactStaffProcessor = new();

                    foreach (var item in items)
                    {
                        List<Photo> lstPropertyPhotos = new();
                        List<ContactStaff> lstPropertyContactStaffs = new();

                        if (item != null && item["address"].HasValues && item["address"]["country"].HasValues)
                        {
                            lstCountry.Add(ExtractCountryData(item["address"]["country"]));
                        }
                        if (item != null && item["photos"].HasValues)
                        {
                            foreach (var photo in item["photos"])
                            {
                                lstPropertyPhotos.Add(ExtractPhotoData(photo, checkNullForInt(item["id"]?.ToString())));
                            }
                        }
                        if (item != null && item["contactStaff"].HasValues)
                        {
                            foreach (var contactStaff in item["contactStaff"])
                            {
                                if (!lstPropertyContactStaffs.Exists(x => x.CrmContactStaffId.ToString() == contactStaff["id"].ToString()))
                                {
                                    List<PhoneNumber> lstPhnNumber = new();
                                    foreach (var phoneNumber in contactStaff["phoneNumbers"])
                                    {
                                        lstPhnNumber.Add(contactStaffProcessor.ExtractPhoneNumberData(phoneNumber, Convert.ToInt32(contactStaff["id"])));
                                    }
                                    ContactStaff objContactStaff = contactStaffProcessor.ExtractContactStaffData(contactStaff);
                                    objContactStaff.PhoneNumbers = lstPhnNumber;
                                    lstPropertyContactStaffs.Add(objContactStaff);
                                    lstPhoneNumbers.AddRange(lstPhnNumber);
                                }
                            }
                        }
                        Property objProperty = new();
                        objProperty = ExtractPropertyData(item);
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

                    PropertyClassProcessor propertyClassProcessor = new();
                    await propertyClassProcessor.UpsertPropertyClassData(scope, lstpropertClass);
                    
                    await propertTypeProcessor.UpsertPropertyTypeData(scope, lstpropertyType);

                    await UpsertCountryData(scope, lstCountry);
                    await UpsertPropertyData(scope, lstProperty);
                    await UpsertPhotoData(scope, lstPhoto);
                    await contactStaffProcessor.UpsertContactStaffData(scope, lstContactStaff);
                    await contactStaffProcessor.UpsertPhoneNumberData(scope, lstPhoneNumbers);
                    await UpsertPropertyContactStaffData(scope, lstProperty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private Property ExtractPropertyData(JToken item)
        {
            return new()
            {
                Id = 0,
                CrmPropertyId = checkNullForInt(item["id"]?.ToString()),
                DisplayAddress = item["displayAddress"]?.ToString(),
                Bath = checkNullForInt(item["bath"]?.ToString()),
                Bed = checkNullForInt(item["bed"]?.ToString()),
                Carports = checkNullForInt(item["carports"]?.ToString()),
                FloorAreaValue = checkNullForInt(item["floorArea"]["value"]?.ToString()),
                FloorAreaUnit = item["floorArea"]["units"]?.ToString(),
                SearchPrice = (float)checkNullForDouble(item["searchPrice"]?.ToString()),
                DisplayPrice = (float)checkNullForDouble(item["displayPrice"]?.ToString()),
                Description = item["description"]?.ToString(),
                Status = item["status"]?.ToString(),
                YearBuilt = checkNullForInt(item["yearBuilt"]?.ToString()),
                Stories = 0,//item["stories"]
                ReceptionRooms = checkNullForInt(item["ReceptionRooms"]?.ToString()),
                VolumeNumber = item["VolumeNumber"]?.ToString(),
                SaleLifeId = checkNullForInt(item["SaleLifeId"]?.ToString()),
                LeaseLifeId = checkNullForInt(item["LeaseLifeId"]?.ToString()),
                IsActive = true,
                IsDeleted = false,
                Inserted = Convert.ToDateTime(item["inserted"]),
                Modified = Convert.ToDateTime(item["modified"]),
                IsAdminUpdated = false,
                CountryId = checkNullForInt(item["address"]["country"]["id"]?.ToString()),
                Level = item["address"]["level"]?.ToString(),
                Street = item["address"]["street"]?.ToString(),
                StreetNumber = item["address"]["streetNumber"]?.ToString(),
                SuburbId = checkNullForInt(item["address"]["suburb"]["id"]?.ToString()),
                UnitNumber = item["address"]["unitNumber"]?.ToString(),
                Latitude = checkNullForDouble(item["geolocation"]["latitude"]?.ToString()),
                Longitude = checkNullForDouble(item["geolocation"]["longitude"]?.ToString()),
                Accuracy = item["geolocation"]["accuracy"]?.ToString(),
                PropertyTypeId = checkNullForInt(item["type"]["id"]?.ToString()),
                CreatedBy = "ContactStaffProcessor",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifieldBy = "ContactStaffProcessor"
            };
        }
        private Country ExtractCountryData(JToken address)
        {
            Country objCountry = JsonConvert.DeserializeObject<Country>(address.ToString());
            objCountry.CrmCountryId = objCountry.Id;
            objCountry.Id = 0;
            objCountry.CreatedBy = ERConstants.PROPERTY_PROCESSOR;
            objCountry.CreatedDate = DateTime.Now;
            objCountry.ModifiedDate = DateTime.Now;
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
            objPhoto.CreatedDate = DateTime.Now;
            objPhoto.ModifiedDate = DateTime.Now;
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
            await propertyRepo.UpsertPropertys(lstProperty.Select(x => x)
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
         
    }
}
