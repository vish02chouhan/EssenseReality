using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EssenseReality.Domain.ViewModels
{
    public class SuburbViewModel
    {
        public string Postcode { get; set; }
        public string Name { get; set; }
        public StateViewModel State { get; set; }
    }


}
