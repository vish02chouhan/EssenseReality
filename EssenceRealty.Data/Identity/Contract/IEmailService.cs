using EssenceRealty.Data.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Data.Identity.Contract
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
