namespace EssenseReality.Domain.Models
{
    public class Country : WhoFields
    {
        public string Isocode { get; set; }
        public int Id { get; set; }
        public double GstRate { get; set; }
        public string Name { get; set; }
    }


}
