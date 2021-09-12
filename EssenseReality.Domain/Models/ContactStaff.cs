using System;
using System.Collections.Generic;

namespace EssenseReality.Domain.Models
{
    public class ContactStaff : WhoFields
    {
        public string FirstName { get; set; }
        public Photo Photo { get; set; }
        public int StaffTypeId { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public bool AdminAccess { get; set; }
        public string Position { get; set; }
        public DateTime LastLogin { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string WebsiteUrl { get; set; }
        public List<Permission> Permissions { get; set; }
        public string Username { get; set; }
    }


}
