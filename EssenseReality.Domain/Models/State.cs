using System;
using System.ComponentModel.DataAnnotations;

namespace EssenseReality.Domain.Models
{
    public class State : WhoFields
    {
        [Key]
        public Guid StateId { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }


}
