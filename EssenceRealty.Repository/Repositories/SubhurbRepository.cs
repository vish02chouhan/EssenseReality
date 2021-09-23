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
    public class SubhurbRepository : BaseRepository<Suburb>, ISubhurbRepository
    {
    public SubhurbRepository(EssenseRealityContext dbContext) : base(dbContext)
    {
    }

    public async Task AddSubhurbs(List<Suburb> lstSuburb)
    {
        await AddRangeAsync(lstSuburb);
    }
}
}
