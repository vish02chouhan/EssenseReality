using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenseReality.Domain.Models
{
    public class CrmEssenceTransaction : WhoFields
    {
        public int Id { get; set; }
        public string DataId { get; set; }
        public int CrmEssenceLogId { get; set; }
        public CrmEssenceLog CrmEssenceLog { get; set; }
        public string JsonObject { get; set; }
        public LogTransactionStatus Status { get; set; }
        public EssenceObjectTypes EssenceObjectTypes { get; set; }
        public string Description { get; set; }
        public int Retry { get; set; }
    }
}