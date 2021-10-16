using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class SubhurbRepository : BaseRepository<Suburb>, ISubhurbRepository
    {
        public SubhurbRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertSubhurbs(List<Suburb> lstSuburb)
        {
            var lstSuburbIds = lstSuburb.Select(x => x.CrmSuburbId).Distinct().ToList();
            var lstDBCrmSuburbIds = _dbContext.Suburbs.Where(x => lstSuburbIds.Contains(x.CrmSuburbId)).Select(x => x.CrmSuburbId).Distinct().ToList();
            lstSuburb.RemoveAll(x => lstDBCrmSuburbIds.Contains(x.CrmSuburbId)); 

            if (lstSuburb.Count > 0)
            {
                var lstDBStateIds = lstSuburb.Select(x => x.State.CrmStateId).Distinct().ToList();
                var lstUpdatedStateDetails = _dbContext.States.Where(x => lstDBStateIds.Contains(x.CrmStateId)).Select(x => new { Id = x.Id, CrmStateId = x.CrmStateId }).Distinct().ToList();
                foreach (var item in lstSuburb)
                {
                    item.StateId = lstUpdatedStateDetails.Where(x => x.CrmStateId == item.State.CrmStateId).First().Id;
                }
                await _dbContext.Suburbs.UpsertRange(lstSuburb).On(x => x.CrmSuburbId).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
