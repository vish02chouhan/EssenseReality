using EssenceRealty.Repository.IRepositories;
using EssenseReality.Data;
using EssenseReality.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class ContactStaffRepository : BaseRepository<ContactStaff>, IContactStaffRepository
    {
        public ContactStaffRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertContactStaffs(IList<ContactStaff> lstContactStaff)
        {
            var lstUpdatedPhoneNumbers = _dbContext.PhoneNumbers.ToList();
            var lstUpdatedPhotos = _dbContext.Photos.ToList();
            foreach (var item in lstContactStaff)
            {
                item.PhoneNumberId = lstUpdatedPhoneNumbers.Where(x => x.CrmPhoneNumberId == item.PhoneNumber.CrmPhoneNumberId).First().Id;
                item.PhoneNumber = lstUpdatedPhoneNumbers.Where(x => x.CrmPhoneNumberId == item.PhoneNumber.CrmPhoneNumberId).First();

                item.PhotoId = lstUpdatedPhotos.Where(x => x.CrmPhotoId == item.Photo.CrmPhotoId).First().Id;
                item.Photo = lstUpdatedPhotos.Where(x => x.CrmPhotoId == item.Photo.CrmPhotoId).First();
            }
            await _dbContext.ContactStaffs.UpsertRange(lstContactStaff).On(x => x.CrmContactStaffId).RunAsync();
            await _dbContext.SaveChangesAsync();

        }
    }
}
