using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EssenceRealty.Domain.ViewModels
{
    public class SuburbViewModel
    {
        public int Id { get; set; }
        public string Postcode { get; set; }
        public string Name { get; set; }
    }


}
