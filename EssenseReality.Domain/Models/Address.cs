namespace EssenseReality.Domain.Models
{
    public class Address : WhoFields
    {
        public int Id {  get; set; }
        public string Level { get; set; }
        public string UnitNumber { get; set; }
        public State State { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public Country Country { get; set; }
        public Suburb Suburb { get; set; }
    }


}
