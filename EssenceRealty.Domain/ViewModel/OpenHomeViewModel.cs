using System;
using System.Collections.Generic;

namespace EssenceRealty.Domain.ViewModels
{
    public class OpenHomeViewModel 
    {
        public int Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int PropertyId { get; set; }
    }
}
