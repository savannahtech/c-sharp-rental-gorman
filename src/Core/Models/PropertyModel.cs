namespace Core.Models
{
    public class PropertyModel : BaseModel
    {
        public long Id { get; set; }
        public string ShortDescription {  get; set; }
        public string Description { get; set; }
        public PropertyRentModel PropertyRent { get; set; }
        public PropertySaleModel PropertySale { get; set; }
        public PropertyLocationModel Location { get; set; }
        public BusinessModel Business { get; set; }
        public List<PropertyFeatureModel> PropertyFeatures { get; set; } = new List<PropertyFeatureModel>();
        public List<PropertyMediaModel> PropertyMedias { get; set; } = new List<PropertyMediaModel>();
    }
}
