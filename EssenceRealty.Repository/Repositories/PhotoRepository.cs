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
            await _dbContext.Photos.UpsertRange(lstPhoto).On(x => x.CrmPhotoId).RunAsync();
            await _dbContext.SaveChangesAsync();

        }
    }
}
