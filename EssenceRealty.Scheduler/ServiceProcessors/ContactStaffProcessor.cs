using EssenceRealty.Repository.IRepositories;
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
    public class ContactStaffProcessor
    {
        public async Task ProcessContactStaffData(IServiceProvider serviceProvider, JArray items)
        {
            try
            {

                var ss = items.SelectTokens("$..marketingUser");
                List<ContactStaff> lstContactStaff = new List<ContactStaff>();
                List<PhoneNumber> lstPhoneNumber = new List<PhoneNumber>();

                foreach (var item in ss)
                {
                    if (item != null && item["user"].HasValues)
                    {
                        lstContactStaff.Add(new()
                        {
                            Id = 0,
                            CrmContactStaffId = Convert.ToInt32(item["user"]["id"]),
                            AdminAccess = null,
                            Email = item["user"]["email"]?.ToString(),
                            FirstName = item["user"]["firstName"]?.ToString(),
                            Inserted = null,//Convert.ToDateTime(item["user"]["inserted"]),
                            LastLogin = null,
                            LastName = item["user"]["lastName"]?.ToString(),
                            Modified = null,//Convert.ToDateTime(item["user"]["modified"]),
                            Position = item["user"]["position"]?.ToString(),
                            Role = item["user"]["role"]?.ToString(),
                            StaffTypeId = 0,
                            Username = null,
                            WebsiteUrl = null,
                            OriginalPhotoURL = item["user"]["photo"].SelectToken("original")?.ToString(),
                            Thumb_360PhotoURL = item["user"]["photo"].SelectToken("thumb_360")?.ToString(),
                            CreatedBy = "ContactStaffProcessor",
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            ModifieldBy = "ContactStaffProcessor"
                        });

                        if (item != null && item["user"]["phoneNumbers"].HasValues)
                        {
                            lstPhoneNumber.Add(new()
                            {
                                Id = 0,
                                ContactStaffId = Convert.ToInt32(item["user"]["id"]),
                                Number = item["user"]["phoneNumbers"].First()?.SelectToken("number")?.ToString(),
                                Type = item["user"]["phoneNumbers"].First()?.SelectToken("type")?.ToString(),
                                TypeCode = item["user"]["phoneNumbers"].First()?.SelectToken("typeCode")?.ToString()
                            });
                        }
                    }
                }

                //var lstContactStaffs = lstContactStaff.Select(x => x)
                //            .Where(x => x != null && x.CrmContactStaffId > 0).ToList()
                //            .GroupBy(elem => elem.CrmContactStaffId)
                //            .Select(group => group.First()).ToList();

                //var lstPhoneNumbers = lstPhoneNumber.Select(x => x)
                //            .Where(x => x != null && x.ContactStaffId > 0).ToList()
                //            .GroupBy(elem => elem.ContactStaffId)
                //            .Select(group => group.First()).ToList();

                using var scope = serviceProvider.CreateScope();
                var contactStaffRepo = scope.ServiceProvider.GetRequiredService<IContactStaffRepository>();
                await contactStaffRepo.UpsertContactStaffs(lstContactStaff.Select(x => x)
                            .Where(x => x != null && x.CrmContactStaffId > 0).ToList()
                            .GroupBy(elem => elem.CrmContactStaffId)
                            .Select(group => group.First()).ToList());
                var phoneNumberRepo = scope.ServiceProvider.GetRequiredService<IPhoneNumberRepository>();
                await phoneNumberRepo.UpsertPhoneNumbers(lstPhoneNumber.Select(x => x)
                            .Where(x => x != null && x.ContactStaffId > 0).ToList()
                            .GroupBy(elem => elem.ContactStaffId)
                            .Select(group => group.First()).ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
