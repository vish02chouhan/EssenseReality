using System.Collections.Generic;

namespace EssenceRealty.Domain.Models
{
    public class FloorPlan
    {
        public int Id { get; set; }
        public List<FloorPlanFile> FloorPlanFiles { get; set; }
        public string Description { get; set; }
        public bool IsActive { get;set; }
        public Property Property { get;set;  }
        public int PropertyId { get;set;  }

    }
}
