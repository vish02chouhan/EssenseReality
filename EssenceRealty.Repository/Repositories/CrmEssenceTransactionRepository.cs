using EssenceRealty.Repository.IRepositories;
using EssenseReality.Data;
using EssenseReality.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class CrmEssenceTransactionRepository : BaseRepository<CrmEssenceTransaction>, ICrmEssenceTransactionRepository
    {
        public CrmEssenceTransactionRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task<CrmEssenceTransaction> AddCrmEssenceLog(CrmEssenceTransaction crmEssenceTransaction)
        {
            return await AddAsync(crmEssenceTransaction);
        }
    }
}
