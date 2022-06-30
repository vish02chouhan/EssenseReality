using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;

namespace EssenceRealty.Repository.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }
    }


}
