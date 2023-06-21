using Data.Models;
using NetTopologySuite.Geometries;
namespace Data.Entities;

public class PropertyLocation : BaseEntity
{
    public int PropertyLocationId { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string Town { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    
    public Property Property { get; set; }
    public Point Coordinates { get; set; }
    public int PropertyId { get; set; }
}