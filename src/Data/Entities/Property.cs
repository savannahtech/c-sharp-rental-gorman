using System.ComponentModel.DataAnnotations.Schema;
using Data.Models;

namespace Data.Entities;

public class Property : BaseEntity
{
    public int PropertyId { get; set; }
    public string ShortDescription { get; set; }
  
    public long Reference { get; set; }
    public string Url { get; set; }
    public bool Listed { get; set; }
    public string Description { get; set; }
    public PropertyRental PropertyRental { get; set; }
    public PropertySale PropertySale { get; set; }
    public PropertyLocation PropertyLocation { get; set; }
    public int? BusinessId { get; set; }
    public Business Business { get; set; }
    public List<PropertyMedia> PropertyMedias { get; set; } = new List<PropertyMedia>();
    public List<PropertyFeature> PropertyFeatures { get; set; } = new List<PropertyFeature>();
    public List<PropertyView> PropertyViews { get; set; } = new List<PropertyView>();
}