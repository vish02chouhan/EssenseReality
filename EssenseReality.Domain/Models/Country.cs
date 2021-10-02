namespace EssenseReality.Domain.Models
{
    public class Country : WhoFields
    {
        public int Id { get; set; }
        public string Isocode { get; set; }
        public int CrmCountryId { get; set; }
        public double GstRate { get; set; }
        public string Name { get; set; }
    }


}
