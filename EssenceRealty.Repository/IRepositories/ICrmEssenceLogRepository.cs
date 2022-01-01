using EssenceRealty.Domain.Enums;
using EssenceRealty.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.IRepositories
{
    public interface ICrmEssenceLogRepository
    {
        Task<CrmEssenceLog> AddCrmEssenceLog(CrmEssenceLog crmEssenceLog);
        Task<IList<CrmEssenceLog>> GetCrmEssenceLog(Guid processingGroupId);
        Task<IList<CrmEssenceLog>> GetCrmEssenceLog(Guid processingGroupId, EssenceObjectTypes essenceObjectTypes);
        Task<int> UpdateCrmEssenceLog(CrmEssenceLog crmEssenceLog);
        Task<CrmEssenceLog> GetPropertyFeatureJson(Guid processingGroupId, int crmPropertyId);
        Task<CrmEssenceLog> GetOpenHomeJson(Guid processingGroupId, int crmPropertyId);
    }
}
