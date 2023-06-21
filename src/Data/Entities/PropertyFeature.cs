using Data.Models;

namespace Data.Entities;

public class PropertyFeature : BaseEntity
{
    public int PropertyFeatureId { get; set; }
    public int PropertyLocationId { get; set; }
    public string Description { get; set; }
    public int FeatureTypeId { get; set; }
    public FeatureType  FeatureType { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
}