namespace EssenceRealty.Domain.Models
{
    public class PropertyFeatureProperty
    {
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public int PropertyFeatureId { get; set; }
        public PropertyFeature PropertyFeature { get; set; }
    }
}
