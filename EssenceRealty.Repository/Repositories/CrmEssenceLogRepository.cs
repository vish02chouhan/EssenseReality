﻿using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Data;
using EssenceRealty.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssenceRealty.Domain.Enums;

namespace EssenceRealty.Repository.Repositories
{
    class CrmEssenceLogRepository : BaseRepository<CrmEssenceLog>, ICrmEssenceLogRepository
    {
        public CrmEssenceLogRepository(EssenceRealtyContext dbContext) : base(dbContext)
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
                                       && x.Retry < 3);
        }
        public async Task<CrmEssenceLog> GetPropertyFeatureJson(Guid processingGroupId, int crmPropertyId)
        {
            return await GetAsync(x => x.ProcessingGroupId == processingGroupId &&
                                       (x.Status == LogTransactionStatus.Pending || x.Status == LogTransactionStatus.Failed)
                                       && x.Retry < 3 && x.EndPointUrl.Contains(crmPropertyId.ToString())
                                       && x.EssenceObjectTypes == EssenceObjectTypes.PropertyFeatures);
        }
        public async Task<CrmEssenceLog> GetOpenHomeJson(Guid processingGroupId, int crmPropertyId)
        {
            return await GetAsync(x => x.ProcessingGroupId == processingGroupId &&
                                       (x.Status == LogTransactionStatus.Pending || x.Status == LogTransactionStatus.Failed)
                                       && x.Retry < 3 && x.EndPointUrl.Contains(crmPropertyId.ToString())
                                       && x.EssenceObjectTypes == EssenceObjectTypes.OpenHome);
        }
        public async Task<int> UpdateCrmEssenceLog(CrmEssenceLog crmEssenceLog)
        {
             _dbContext.Update(crmEssenceLog);
            return await _dbContext.SaveChangesAsync();
        }
    }

}
