using EssenceRealty.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Domain.Models
{
    public class CrmEssenceTransaction : WhoFields
    {
        public int Id { get; set; }
        public int CrmEssenceLogId { get; set; }
        public CrmEssenceLog CrmEssenceLog { get; set; }
        public string JsonObject { get; set; }
        public EssenceObjectTypes EssenceObjectTypes { get; set; }
        public string ErrorDescription { get; set; }
    }
}