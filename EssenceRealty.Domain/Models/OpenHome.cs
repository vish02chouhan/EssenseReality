using System;
using System.Collections.Generic;

namespace EssenceRealty.Domain.Models
{
    public class OpenHome : WhoFields
    {
        public int Id { get; set; }
        public int? CrmOpenHomeId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
