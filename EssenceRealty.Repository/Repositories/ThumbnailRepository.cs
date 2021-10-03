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
    public class ThumbnailRepository //: BaseRepository<Suburb>, IThumbnailRepository
    {
        //public ThumbnailRepository(EssenseRealityContext dbContext) : base(dbContext)
        //{
        //}

        //public async Task UpsertThumbnails(IList<Thumbnail> lstThumbnail)
        //{
        //    await _dbContext.Thumbnails.UpsertRange(lstThumbnail).On(x => x.Thumb1024).RunAsync();
        //    await _dbContext.SaveChangesAsync();

        //}
    }
}
