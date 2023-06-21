using Data.Models;

namespace Data.Entities;

public class FeatureType : BaseEntity
{   
    public int FeatureTypeId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public List<PropertyFeature> PropertyFeatures { get; set; } = new List<PropertyFeature>();
}