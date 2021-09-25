using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EssenseReality.Domain.Models
{
    public class State : WhoFields
    {

        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public int CrmStateId { get; set; }
        public ICollection<Suburb> Suburb { get; set; }
    }
}
