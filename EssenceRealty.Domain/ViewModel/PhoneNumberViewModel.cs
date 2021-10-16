using System.Collections.Generic;

namespace EssenceRealty.Domain.ViewModels
{
    public class PhoneNumber
    {
        public string Number { get; set; }
        public string TypeCode { get; set; }
        public string Type { get; set; }
        public ContactStaffViewModel ContactStaff { get; set; }
    }


}
