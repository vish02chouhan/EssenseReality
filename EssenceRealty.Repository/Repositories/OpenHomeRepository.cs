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
    public class OpenHomeRepository : BaseRepository<OpenHome>, IOpenHomeRepository
    {
        public OpenHomeRepository(EssenceRealtyContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertOpenHome(List<OpenHome> lstOpenHome, int crmPropertyId)
        {
            var lstOpenHomeIds = lstOpenHome.Select(x => x.CrmOpenHomeId).Distinct().ToList();
            var lstDBCrmOpenHomeIds = _dbContext.OpenHomes.Where(x => lstOpenHomeIds.Contains(x.CrmOpenHomeId)).Select(x => x.CrmOpenHomeId).Distinct().ToList();
            lstOpenHome.RemoveAll(x => lstDBCrmOpenHomeIds.Contains(x.CrmOpenHomeId));

            if (lstOpenHome.Count > 0)
            {
                var propertyId = _dbContext.Properties.Where(x => x.CrmPropertyId == crmPropertyId).Select(x => x.Id).FirstOrDefault();
                foreach (var item in lstOpenHome)
                {
                    item.PropertyId = propertyId;
                }
                await _dbContext.OpenHomes.UpsertRange(lstOpenHome).On(x => x.CrmOpenHomeId).RunAsync();
            }
        }
    }
}
