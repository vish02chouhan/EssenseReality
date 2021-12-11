using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Domain.Models
{
   public abstract class WhoFields
    {
        public string CreatedBy { get; set; } 
        public DateTime? CreatedDate { get; set; } = System.DateTime.Now;
        public string ModifieldBy { get; set; }
        public DateTime? ModifiedDate { get; set; } = System.DateTime.Now;
    }
}
