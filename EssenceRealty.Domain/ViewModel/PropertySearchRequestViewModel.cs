using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Domain.ViewModels
{
    public class PropertySearchRequest
    {
        public int[] PropertyTypeId { get; set; }
        public int? BedsMin { get; set; }
        public int? BedsMax { get; set; }
        public float? PriceMin { get; set; }
        public float? PriceMax { get; set; }
                  
    }
}
