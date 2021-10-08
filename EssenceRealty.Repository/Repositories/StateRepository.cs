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
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertStates(List<State> lstStates)
        {
            var lstStateIds = lstStates.Select(x => x.CrmStateId).Distinct().ToList();
            var lstDBCrmStateIds = _dbContext.States.Where(x => lstStateIds.Contains(x.CrmStateId)).Select(x => x.CrmStateId).Distinct().ToList();
            lstStates.RemoveAll(x => lstDBCrmStateIds.Contains(x.CrmStateId));
            if (lstStates.Count > 0)
            {
                await _dbContext.States.UpsertRange(lstStates).On(x => x.CrmStateId).RunAsync();
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
