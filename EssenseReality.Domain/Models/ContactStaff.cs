using System;
using System.Collections.Generic;

namespace EssenseReality.Domain.Models
{
    public class ContactStaff : WhoFields, ICrmWhoFields
    {
        public int Id { get; set; }
        public int CrmContactStaffId { get; set; }
        public string FirstName { get; set; }
        public int StaffTypeId { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool AdminAccess { get; set; }
        public string Position { get; set; }
        public DateTime LastLogin { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public string Username { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime Modified { get; set; }
        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }

    }


}
