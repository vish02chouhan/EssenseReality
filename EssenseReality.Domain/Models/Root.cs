using System.Collections.Generic;

namespace EssenseReality.Domain.Models
{
    public class Root
    {
        public List<Property> Items { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public Urls Urls { get; set; }
    }


}
