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
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPhotos(List<Photo> lstPhoto)
        {
            var lstPhotoIds = lstPhoto.Select(x => x.CrmPhotoId).Distinct().ToList();
            var lstDBCrmPhotoIds = _dbContext.Photos.Where(x => lstPhotoIds.Contains(x.CrmPhotoId)).Select(x => x.CrmPhotoId).Distinct().ToList();
            lstPhoto.RemoveAll(x => lstDBCrmPhotoIds.Contains(x.CrmPhotoId));

            if (lstPhoto.Count > 0)
            {
                var lstPropertyIds = lstPhoto.Select(x => x.PropertyId).Distinct().ToList();
                var lstDBPropertyDetails = _dbContext.Properties.Where(x => lstPropertyIds.Contains(x.CrmPropertyId)).Select(x => new { Id = x.Id, CrmPropertyId = x.CrmPropertyId }).Distinct().ToList();
                foreach (var item in lstPhoto)
                {
                    item.PropertyId = lstDBPropertyDetails.Where(x => x.CrmPropertyId == item.PropertyId).First().Id;
                }
                await _dbContext.Photos.UpsertRange(lstPhoto).On(x => x.CrmPhotoId).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
