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
                List<string> lst = new List<string>();
                foreach (var item in items)
                {
                    if (!string.IsNullOrEmpty(item.SelectToken("marketingUser").SelectToken("user").ToString())) 
                    {
                        lst.Add(item.SelectToken("marketingUser").SelectToken("user").ToString());
                    }
                }
                var lstContactStaffs = JsonConvert.DeserializeObject<IList<ContactStaff>>(lst.ToString())
                                  .Where(x => x != null && x.Id > 0).ToList()
                                  .Select<ContactStaff, ContactStaff>(p => new ContactStaff
                                  {
                                      Id = 0,
                                      CrmContactStaffId = p.Id,
                                      AdminAccess = p.AdminAccess,
                                      Email = p.Email,
                                      FirstName = p.FirstName,
                                      Inserted = p.Inserted,
                                      LastLogin = p.LastLogin,
                                      LastName = p.LastName,
                                      Modified = p.Modified,
                                      PhoneNumber = new PhoneNumber()
                                      {
                                          Id = 0,
                                          CrmPhoneNumberId = p.PhoneNumber.Id,
                                          Number = p.PhoneNumber.Number,
                                          Type = p.PhoneNumber.Type,
                                          TypeCode = p.PhoneNumber.TypeCode
                                      },
                                      PhoneNumberId = p.PhoneNumberId,
                                      Photo = new Photo()
                                      {
                                          Id = 0,
                                          CrmPhotoId = p.Photo.Id,
                                          Type = p.Photo.Type,
                                          Filename = p.Photo.Filename,
                                          Filesize = p.Photo.Filesize,
                                          Height = p.Photo.Height,
                                          Inserted = p.Photo.Inserted,
                                          Modified = p.Photo.Modified,
                                          Published = p.Photo.Published,
                                          Url = p.Photo.Url,
                                          UserFilename = p.Photo.UserFilename,
                                          Width = p.Photo.Width
                                      },
                                      PhotoId = p.PhotoId,
                                      Position = p.Position,
                                      Role = p.Role,
                                      StaffTypeId = p.StaffTypeId,
                                      Username = p.Username,
                                      WebsiteUrl = p.WebsiteUrl,
                                      CreatedBy = "ContactStaffProcessor",
                                      CreatedDate = DateTime.Now,
                                      ModifiedDate = DateTime.Now,
                                      ModifieldBy = "ContactStaffProcessor"
                                  }).ToList();

                var lstPhoneNumbers = lstContactStaffs.Select(x => x.PhoneNumber)
                            .Where(x => x != null && x.CrmPhoneNumberId > 0).ToList()
                            .GroupBy(elem => elem.CrmPhoneNumberId)
                            .Select(group => group.First()).ToList();

                var lstPhotos = lstContactStaffs.Select(x => x.Photo)
                            .Where(x => x != null && x.CrmPhotoId > 0).ToList()
                            .GroupBy(elem => elem.CrmPhotoId)
                            .Select(group => group.First()).ToList();

                using var scope = serviceProvider.CreateScope();
                var phoneNumberRepo = scope.ServiceProvider.GetRequiredService<IPhoneNumberRepository>();
                await phoneNumberRepo.UpsertPhoneNumbers(lstPhoneNumbers);
                var photoRepo = scope.ServiceProvider.GetRequiredService<IPhotoRepository>();
                await photoRepo.UpsertPhotos(lstPhotos);
                var contactStaffRepo = scope.ServiceProvider.GetRequiredService<IContactStaffRepository>();
                await contactStaffRepo.UpsertContactStaffs(lstContactStaffs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
