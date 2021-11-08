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
    public class EssenceObjectRequiredApprovalRepository : BaseRepository<EssenceObjectRequiredApproval>, IEssenceObjectRequiredApprovalRepository
    {
        public EssenceObjectRequiredApprovalRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPropertys(List<EssenceObjectRequiredApproval> lstEssenceObjectRequiredApproval)
        {
            await _dbContext.EssenceObjectRequiredApprovals.UpsertRange(lstEssenceObjectRequiredApproval).On(x=> x.CrmPropertyId).RunAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async override Task<IReadOnlyList<EssenceObjectRequiredApproval>> ListAllAsync()
        {
            return await _dbContext.EssenceObjectRequiredApprovals
                        .Where(x => x.EssenceObjectRequiredApprovalStatus == EssenceObjectRequiredApprovalStatus.Pending)
                        .AsNoTracking().ToListAsync();
        }
    }
}
