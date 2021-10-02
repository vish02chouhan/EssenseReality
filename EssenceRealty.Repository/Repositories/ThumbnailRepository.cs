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
    public class ThumbnailRepository : BaseRepository<Suburb>, IThumbnailRepository
    {
        public ThumbnailRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertThumbnails(IList<Thumbnail> lstThumbnail)
        {
            //var lstUpdatedStates = _dbContext.States.ToList();
            //foreach (var item in lstSuburb)
            //{
            //    item.StateId = lstUpdatedStates.Where(x => x.CrmStateId == item.State.CrmStateId).First().Id;
            //    item.State = lstUpdatedStates.Where(x => x.CrmStateId == item.State.CrmStateId).First();
            //}
            //await _dbContext.Suburbs.UpsertRange(lstSuburb).On(x => x.CrmSuburbId).RunAsync();
            await _dbContext.SaveChangesAsync();

        }
    }
}
