using Core.Models;

namespace Core.Property
{
    public class AddOrUpdatePropertyModel
    {
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string? Url { get; set; }
        public PropertyLocationModel PropertyLocation { get; set; }
        public List<PropertyFeatureModel> PropertyFeatures { get; set; } = new List<PropertyFeatureModel>();
    }
}
