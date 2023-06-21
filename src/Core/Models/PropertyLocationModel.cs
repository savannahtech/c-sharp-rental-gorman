using NetTopologySuite.Geometries;

namespace Core.Models
{
    public class PropertyLocationModel
    {
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
 
    }
}
