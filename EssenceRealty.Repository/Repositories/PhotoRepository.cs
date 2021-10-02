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

        public async Task UpsertPhotos(IList<Photo> lstPhoto)
        {
            var lstUpdatedProperties = _dbContext.Properties.ToList();
            var lstUpdatedThumbnails = _dbContext.Thumbnails.ToList();
            foreach (var item in lstPhoto)
            {
                item.PropertyId = lstUpdatedProperties.Where(x => x.CrmPropertyId == item.PropertyId).First().Id;
                item.ThumbnailId = lstUpdatedThumbnails.Where(x => x.Thumb1024 == item.Thumbnail.Thumb1024 && x.Thumb180 == item.Thumbnail.Thumb180).First().Id;
            }
            await _dbContext.Photos.UpsertRange(lstPhoto).On(x => x.CrmPhotoId).RunAsync();
            await _dbContext.SaveChangesAsync();

        }
    }
}
