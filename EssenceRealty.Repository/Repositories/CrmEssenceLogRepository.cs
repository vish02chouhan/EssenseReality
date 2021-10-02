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
    class CrmEssenceLogRepository : BaseRepository<CrmEssenceLog>, ICrmEssenceLogRepository
    {
        public CrmEssenceLogRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task<CrmEssenceLog> AddCrmEssenceLog(CrmEssenceLog crmEssenceLog)
        {
           return await AddAsync(crmEssenceLog);
        }

        public async Task<IList<CrmEssenceLog>> GetCrmEssenceLog(Guid processingGroupId)
        {
            return await GetManyAsync(x => x.ProcessingGroupId == processingGroupId && 
                                       (x.Status == LogTransactionStatus.Pending || x.Status == LogTransactionStatus.Failed) 
                                       && x.Retry < 3 && x.EssenceObjectTypes == EssenceObjectTypes.Contacts);
        }

        public async Task<int> UpdateCrmEssenceLog(CrmEssenceLog crmEssenceLog)
        {
             _dbContext.Update(crmEssenceLog);
            return await _dbContext.SaveChangesAsync();
        }
    }

}
