using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenseReality.Domain.Models
{
   public abstract class WhoFields
    {
        public int CreatedBy { get; set; }
        public int CreatedDate { get; set; }
        public int ModifieldBy { get; set; }
        public int ModifiedDate { get; set; }
    }
}
