using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }


        //public async Task<Feedback> AddFloorPlan(Feedback feedback)
        //{
        //    try
        //    {
        //        await _dbContext.Feedbacks.AddAsync(feedback);
        //        await _dbContext.SaveChangesAsync();
        //        return feedback;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public override async Task<Feedback> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Feedbacks.
        //        .Where(x => x.Id == id)
        //        .SingleOrDefaultAsync();
        //}

        //public async Task<FloorPlan> GetByPropertyIdAsync(int id)
        //{
        //    return await _dbContext.FloorPlans.
        //        Include(x => x.FloorPlanFiles)
        //        .Where(x => x.PropertyId == id)
        //        .SingleOrDefaultAsync();
        //}


    }


}
