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

        public async Task AddStates(IEnumerable<State> lstStates)
        {
            await _dbContext.State.UpsertRange(lstStates).On(x => x.Id).RunAsync();
            await _dbContext.SaveChangesAsync();

        }

    }
}
