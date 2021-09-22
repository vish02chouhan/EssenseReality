using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Scheduler.ExternalServices
{
   public class VaultApiClientOptions
    {
        public string BaseAddress { get; set; }
        public string ApiKey { get; set; }
        public string BearerToken { get; set; }
    }
}
