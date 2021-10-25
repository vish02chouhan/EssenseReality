using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Domain.Models
{
    public class PropertyFeatureGrouping: WhoFields
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupDisplayName { get; set; }
        public ICollection<PropertyFeature> PropertyFeature { get; set; }

    }
}
