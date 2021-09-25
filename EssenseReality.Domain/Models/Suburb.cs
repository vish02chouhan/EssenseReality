using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EssenseReality.Domain.Models
{
    public class Suburb : WhoFields
    {

        public int Id { get; set; }
        public string Postcode { get; set; }
        //public object NzDistrict { get; set; }
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CrmSuburbId { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }


}
