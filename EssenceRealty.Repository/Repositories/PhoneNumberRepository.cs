using EssenceRealty.Repository.IRepositories;
using EssenseReality.Data;
using EssenseReality.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Repository.Repositories
{
    public class PhoneNumberRepository : BaseRepository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(EssenseRealityContext dbContext) : base(dbContext)
        {
        }

        public async Task UpsertPhoneNumbers(IList<PhoneNumber> lstPhoneNumber)
        {
            await _dbContext.PhoneNumbers.UpsertRange(lstPhoneNumber).On(x => x.CrmPhoneNumberId).RunAsync();
            await _dbContext.SaveChangesAsync();

        }
    }
}
