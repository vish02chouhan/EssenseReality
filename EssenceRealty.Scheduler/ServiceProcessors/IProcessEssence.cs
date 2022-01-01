using EssenceRealty.Domain.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace EssenceRealty.Scheduler.ServiceProcessors
{
    public interface IProcessEssence
    {
        Task ProcessJsonData(CrmEssenceLog objCrmEssenceLog);
    }
}
