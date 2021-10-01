using System.Collections.Generic;

namespace EssenseReality.Domain.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public int CrmPhoneNumberId { get; set; }
        public string Number { get; set; }
        public string TypeCode { get; set; }
        public string Type { get; set; }
        public ICollection<ContactStaff> ContactStaff { get; set; }
    }


}
