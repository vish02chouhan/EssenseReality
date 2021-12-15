using System;

namespace EssenceRealty.Domain.ViewModels
{
    public class EnquirySearchRequest
    {
        public string[] EnquiryType { get; set; }
        public DateTime? EnquiryDate { get; set; }
    }
}
