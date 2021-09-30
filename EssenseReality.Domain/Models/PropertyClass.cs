using System.Collections.Generic;

namespace EssenseReality.Domain.Models
{
    public class PropertyClass : WhoFields
    {
        public int Id { get; set; }
        public int CrmPropertyClassId { get; set; }
        public string Name { get; set; }
        public string InternalName { get; set; }
        public ICollection<PropertyType> PropertyType { get; set; }
    }


}
