using System;

namespace EssenceRealty.Domain.ViewModels
{
    public class EnquiryViewModel
    {
        public int Id { get; set; }
        //public Property Property { get; set; }
        public DateTime EnquiryDate { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string OriginalId { get; set; }
        public string PropertyReference { get; set; }
        public string Source { get; set; }
        public int SaleLifeId { get; set; }
        public int LeaseLifeId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
    }
}