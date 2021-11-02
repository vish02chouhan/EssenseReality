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
    public class FloorPlanRepository : BaseRepository<FloorPlan>, IFloorPlanRepository
    {
        public FloorPlanRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }


        public async Task<FloorPlan> AddFloorPlan(FloorPlan floorPlan)
        {
            try
            {
                await _dbContext.FloorPlans.AddAsync(floorPlan);
                await _dbContext.SaveChangesAsync();
                return floorPlan;
            }
            catch (Exception)
            {               
                throw;
            }
        }

        public override async Task<FloorPlan> GetByIdAsync(int id)
        {
            return await _dbContext.FloorPlans.
                Include(x => x.FloorPlanFiles)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<FloorPlan> GetByPropertyIdAsync(int id)
        {
            return await _dbContext.FloorPlans.
                Include(x => x.FloorPlanFiles)
                .Where(x => x.PropertyId == id)
                .SingleOrDefaultAsync();
        }

        public override async Task UpdateAsync(FloorPlan entity)
        {

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

    }
}
