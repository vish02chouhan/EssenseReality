namespace EssenseReality.Domain.Models
{
    public class Geolocation : WhoFields
    {
        public int Id {  get; set; }
        public string Accuracy { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }


}
