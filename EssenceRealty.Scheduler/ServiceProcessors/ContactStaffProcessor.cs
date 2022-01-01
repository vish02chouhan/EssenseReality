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
using EssenceRealty.Data.Identity.Contract;
using EssenceRealty.Data.Identity.Models;
using Serilog;
using EssenceRealty.Domain.Helper;

namespace EssenceRealty.Scheduler.ServiceProcessors
{
    public class ContactsProcessor:IProcessEssence
    {
        private readonly IServiceProvider serviceProvider;
        public ContactsProcessor(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task ProcessJsonData(CrmEssenceLog objCrmEssenceLog)
        {
            var items = JArray.Parse(objCrmEssenceLog.JsonObjectBatch);
            try
            {
                var marketingUser = items.SelectTokens("$..marketingUser");
                List<ContactStaff> lstContactStaff = new();
                List<PhoneNumber> lstPhoneNumber = new();

                foreach (var item in marketingUser)
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
                Log.Error(ex.Message);
                throw;
            }
        }
        public ContactStaff ExtractContactStaffData(JToken item)
        {
            JsonProcessor<ContactStaff> objJsonProcessor = new();
            ContactStaff objContactStaff = (ContactStaff)objJsonProcessor.ExtractData<ContactStaff>(item);
            objContactStaff.CrmContactStaffId = objContactStaff.Id;
            objContactStaff.Id = 0;
            dynamic data = JsonConvert.DeserializeObject(item.ToString());
            objContactStaff.OriginalPhotoURL = data.photo.original?.ToString();
            objContactStaff.Thumb_360PhotoURL = data.photo.thumb_360?.ToString();
            objContactStaff.CreatedBy = ERConstants.CONTACTSTAFF_PROCESSOR;
            objContactStaff.ModifieldBy = ERConstants.CONTACTSTAFF_PROCESSOR;
            return objContactStaff;
        }
        public PhoneNumber ExtractPhoneNumberData(JToken item, int ContactStaffId)
        {
            JsonProcessor<PhoneNumber> objJsonProcessor = new();
            PhoneNumber objPhoneNumber = (PhoneNumber)objJsonProcessor.ExtractData<PhoneNumber>(item);
            objPhoneNumber.Id = 0;
            objPhoneNumber.ContactStaffId = ContactStaffId;
            return objPhoneNumber;
        }
        public async Task UpsertContactStaffData(IServiceScope scope, List<ContactStaff> lstContactStaff)
        {
            var contactStaffRepo = scope.ServiceProvider.GetRequiredService<IContactStaffRepository>();
            await contactStaffRepo.UpsertContactStaffs(lstContactStaff.Select(x => x)
                        .Where(x => x != null && x.CrmContactStaffId > 0).ToList()
                        .GroupBy(elem => elem.CrmContactStaffId)
                        .Select(group => group.First()).ToList());

            await AddRegistredUser(scope, lstContactStaff);
        }
        public async Task UpsertPhoneNumberData(IServiceScope scope, List<PhoneNumber> lstPhoneNumber)
        {
            var phoneNumberRepo = scope.ServiceProvider.GetRequiredService<IPhoneNumberRepository>();
            await phoneNumberRepo.UpsertPhoneNumbers(lstPhoneNumber.Select(x => x)
                        .Where(x => x != null && x.ContactStaffId > 0).ToList()
                        .GroupBy(elem => elem.ContactStaffId)
                        .Select(group => group.First()).ToList());
        }

        public async Task AddRegistredUser(IServiceScope scope, List<ContactStaff> lstContactStaff)
        {
            var authenticationService = scope.ServiceProvider.GetRequiredService<IAuthenticationService>();
            foreach (var item in lstContactStaff)
            {
                var request = new RegistrationRequest
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    UserName = item.Email,
                    Password = $"{item.FirstName.FirstCharToUpper()}@123"
                };
                try
                {
                    await authenticationService.RegisterAsync(request);
                }
                catch
                {
                }
           
            }

        

        }
    }
}
