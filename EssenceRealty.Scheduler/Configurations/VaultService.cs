

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Scheduler.Configurations
{
    public class VaultServicesConfig
    {
        public string Url { get; set; }
        public EssenceMainObject[] EssenceMainObject { get; set; }
    }

    public class EssenceMainObject
    {
        public string Name { get; set; }
        public string[] Url { get; set; }
    }
}
