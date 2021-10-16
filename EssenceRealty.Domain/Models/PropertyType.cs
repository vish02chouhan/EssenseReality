namespace EssenceRealty.Domain.Models
{
    public class PropertyType : WhoFields
    {
        public int Id { get; set; }
        public int CrmPropertyTypeId { get; set; }
        public string Name { get; set; }

        public int PropertyClassId { get; set; }
        public PropertyClass PropertyClass { get; set; }
    }


}
