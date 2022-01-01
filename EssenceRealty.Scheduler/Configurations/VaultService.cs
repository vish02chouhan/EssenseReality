

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
        public int PageSize { get; set; }

        public int Priority { get; set; }
        public int SchedulerInterval { get; set; }
        public EssenceMainObject[] EssenceMainObject { get; set; }
    }

    public class EssenceMainObject
    {
        public string Name { get; set; }
        public bool IsRequiredToProcess { get; set; }
        public string[] Urls { get; set; }
        public int RunsOnDay { get; set; }
        public int Priority { get; set; }
        public QueryString QueryString { get; set; }
    }

    public class QueryString
    {
        public bool Enable { get; set; }   
        public List<string> Sale { get; set; }
        public List<string> Lease { get; set; }
        public List<string> PublishedOnPortals { get; set; }
    }
}
