using System.Collections.Generic;

namespace EssenceRealty.Domain.Models
{
    public class PropertyFeature : WhoFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string DataType { get; set; }
        public string Data { get; set; }
        public int PropertyFeatureGroupingId { get; set; }
        public PropertyFeatureGrouping PropertyFeatureGrouping { get; set; }
        public ICollection<PropertyFeatureProperty> PropertyFeatureProperties { get; set; }
    }
}
