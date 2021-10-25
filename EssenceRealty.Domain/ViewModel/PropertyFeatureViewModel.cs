namespace EssenceRealty.Domain.ViewModels
{
    public class PropertyFeatureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string DataType { get; set; }
        public string Data { get; set; }
        public int PropertyFeatureGroupingId { get; set; }
    }
}
