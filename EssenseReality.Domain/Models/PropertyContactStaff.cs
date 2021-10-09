namespace EssenseReality.Domain.Models
{
    public class PropertyContactStaff
    {
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public int ContactStaffId { get; set; }
        public ContactStaff ContactStaff { get; set; }
    }
}
