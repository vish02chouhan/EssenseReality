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
                        lstContactStaff.Add(ExtractContactStaffData(item["user"]));
                        foreach (var phoneNumber in item["user"]["phoneNumbers"])
                        {
                            if (item != null && phoneNumber.HasValues)
                            {
                                lstPhoneNumber.Add(ExtractPhoneNumberData(phoneNumber, Convert.ToInt32(item["user"]["id"])));
                            }
                        }
                    }
                }

                using var scope = serviceProvider.CreateScope();
                await UpsertContactStaffData(scope, lstContactStaff);
                await UpsertPhoneNumberData(scope, lstPhoneNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public ContactStaff ExtractContactStaffData(JToken item)
        {
            return new()
            {
                Id = 0,
                CrmContactStaffId = Convert.ToInt32(item["id"]),
                //AdminAccess = null,
                Email = item["email"]?.ToString(),
                FirstName = item["firstName"]?.ToString(),
                Inserted = null,
                //LastLogin = null,
                LastName = item["lastName"]?.ToString(),
                Modified = null,
                Position = item["position"]?.ToString(),
                Role = item["role"]?.ToString(),
                StaffTypeId = 0,
                Username = null,
                WebsiteUrl = null,
                OriginalPhotoURL = item["photo"].SelectToken("original")?.ToString(),
                Thumb_360PhotoURL = item["photo"].SelectToken("thumb_360")?.ToString(),
                CreatedBy = ERConstants.CONTACTSTAFF_PROCESSOR,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifieldBy = ERConstants.CONTACTSTAFF_PROCESSOR
            };

        }
        public PhoneNumber ExtractPhoneNumberData(JToken item, int ContactStaffId)
        {
            return new()
            {
                Id = 0,
                ContactStaffId = ContactStaffId,
                Number = item["number"]?.ToString(),
                Type = item["type"]?.ToString(),
                TypeCode = item["typeCode"]?.ToString()
            };
        }
        public async Task UpsertContactStaffData(IServiceScope scope, List<ContactStaff> lstContactStaff)
        {
            var contactStaffRepo = scope.ServiceProvider.GetRequiredService<IContactStaffRepository>();
            await contactStaffRepo.UpsertContactStaffs(lstContactStaff.Select(x => x)
                        .Where(x => x != null && x.CrmContactStaffId > 0).ToList()
                        .GroupBy(elem => elem.CrmContactStaffId)
                        .Select(group => group.First()).ToList());
        }
        public async Task UpsertPhoneNumberData(IServiceScope scope, List<PhoneNumber> lstPhoneNumber)
        {
            var phoneNumberRepo = scope.ServiceProvider.GetRequiredService<IPhoneNumberRepository>();
            await phoneNumberRepo.UpsertPhoneNumbers(lstPhoneNumber.Select(x => x)
                        .Where(x => x != null && x.ContactStaffId > 0).ToList()
                        .GroupBy(elem => elem.ContactStaffId)
                        .Select(group => group.First()).ToList());
        }
    }
}
