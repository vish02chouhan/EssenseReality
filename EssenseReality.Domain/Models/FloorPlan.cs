using System.Collections.Generic;

namespace EssenseReality.Domain.Models
{
    public class FloorPlan
    {
        public int Id { get; set; }
        public List<Photo> Photos { get; set; }
        public string Description { get; set; }
    }


}
