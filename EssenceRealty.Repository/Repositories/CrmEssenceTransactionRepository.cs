using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class CrmEssenceTransactionRepository : BaseRepository<CrmEssenceTransaction>, ICrmEssenceTransactionRepository
    {
        public CrmEssenceTransactionRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

        public async Task<CrmEssenceTransaction> AddCrmEssenceLog(CrmEssenceTransaction crmEssenceTransaction)
        {
            return await AddAsync(crmEssenceTransaction);
        }
    }
}
