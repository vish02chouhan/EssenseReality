﻿using System;
using System.Collections.Generic;

namespace EssenseReality.Domain.ViewModels
{
    public class ContactStaffViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool? AdminAccess { get; set; }
        public string Position { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Email { get; set; }
        public string WebsiteUrl { get; set; }
        public string Username { get; set; }
        public DateTime? Inserted { get; set; }
        public DateTime? Modified { get; set; }
        public string Thumb_360PhotoURL { get; set; }
        public string OriginalPhotoURL { get; set; }
        public ICollection<PhoneNumber> PhoneNumber { get; set; }

    }
}