using System.Collections.Generic;

namespace EssenceRealty.Domain.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string TypeCode { get; set; }
        public string Type { get; set; }
        public int ContactStaffId { get; set; }
        public ContactStaff ContactStaff { get; set; }
    }


}
