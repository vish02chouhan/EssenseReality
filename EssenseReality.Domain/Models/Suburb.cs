using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EssenseReality.Domain.Models
{
    public class Suburb : WhoFields
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SuburbId { get; set; }
        //public State State { get; set; }
        public string Postcode { get; set; }
        //public object NzDistrict { get; set; }
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public State State { get; set; } = new State();
    }


}
