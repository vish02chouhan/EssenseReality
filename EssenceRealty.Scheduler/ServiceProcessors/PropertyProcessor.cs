﻿using EssenceRealty.Repository.IRepositories;
using EssenseReality.Domain.Models;
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
                return 0;
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

        public async Task ProcessPropertyData(IServiceProvider serviceProvider, JArray items)
        {
            try
            {
                if (items.HasValues)
                {
                    List<Property> lstProperty = new List<Property>();
                    List<Photo> lstPhoto = new List<Photo>();
                    List<Country> lstCountry = new List<Country>();

                    foreach (var item in items)
                    {
                            lstProperty.Add(new()
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
                            });

                            if (item != null && item["address"].HasValues && item["address"]["country"].HasValues)
                            {
                                lstCountry.Add(new()
                                {
                                    Id = 0,
                                    CrmCountryId = checkNullForInt(item["address"]["country"]["id"]?.ToString()),
                                    GstRate = checkNullForDouble(item["address"]["country"]["gstRate"]?.ToString()),
                                    Isocode = item["address"]["country"]["isocode"]?.ToString(),
                                    Name = item["address"]["country"]["name"]?.ToString(),
                                    CreatedBy = "ContactStaffProcessor",
                                    CreatedDate = DateTime.Now,
                                    ModifiedDate = DateTime.Now,
                                    ModifieldBy = "ContactStaffProcessor"
                                });
                            }

                        if (item != null && item["photos"].HasValues)
                        {
                            foreach (var photo in item["photos"])
                            {
                                lstPhoto.Add(new()
                                {
                                    Id = 0,
                                    CrmPhotoId = checkNullForInt(photo["id"]?.ToString()),
                                    Filename = photo["filename"]?.ToString(),
                                    Filesize = checkNullForInt(photo["filesize"]?.ToString()),
                                    Height = checkNullForInt(photo["height"]?.ToString()),
                                    Inserted = Convert.ToDateTime(photo["inserted"]),
                                    Modified = Convert.ToDateTime(photo["modified"]),
                                    PropertyId = checkNullForInt(item["id"]?.ToString()),
                                    Published = Convert.ToBoolean(photo["published"]),
                                    Thumb1024 = photo["thumbnails"]["thumb_1024"]?.ToString(),
                                    Thumb180 = photo["thumbnails"]["thumb_180"]?.ToString(),
                                    Type = photo["type"]?.ToString(),
                                    Url = photo["url"]?.ToString(),
                                    UserFilename = photo["userFilename"]?.ToString(),
                                    Width = Convert.ToInt32(photo["width"]?.ToString()),
                                    CreatedBy = "ContactStaffProcessor",
                                    CreatedDate = DateTime.Now,
                                    ModifiedDate = DateTime.Now,
                                    ModifieldBy = "ContactStaffProcessor"
                                });
                            }
                        }
                    }

                    using var scope = serviceProvider.CreateScope();
                    var countryRepo = scope.ServiceProvider.GetRequiredService<ICountryRepository>();
                    await countryRepo.UpsertCountrys(lstCountry.Select(x => x)
                                .Where(x => x != null && x.CrmCountryId> 0).ToList()
                                .GroupBy(elem => elem.CrmCountryId)
                                .Select(group => group.First()).ToList());
                    var propertyRepo = scope.ServiceProvider.GetRequiredService<IPropertyRepository>();
                    await propertyRepo.UpsertPropertys(lstProperty.Select(x => x)
                                .Where(x => x != null && x.CrmPropertyId > 0).ToList()
                                .GroupBy(elem => elem.CrmPropertyId)
                                .Select(group => group.First()).ToList());
                    var photoRepo = scope.ServiceProvider.GetRequiredService<IPhotoRepository>();
                    await photoRepo.UpsertPhotos(lstPhoto.Select(x => x)
                                .Where(x => x != null && x.CrmPhotoId> 0).ToList()
                                .GroupBy(elem => elem.CrmPhotoId)
                                .Select(group => group.First()).ToList());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
