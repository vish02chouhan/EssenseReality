namespace EssenseReality.Domain.Models
{
    public class Suburb : WhoFields
    {
        public State State { get; set; }
        public string Postcode { get; set; }
        //public object NzDistrict { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
