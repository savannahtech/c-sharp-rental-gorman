using Data.Models;

namespace Data.Entities;

public class Business : BaseEntity
{
    public int BusinessId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string TIN { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string PostCode { get; set; }
    public bool Active { get; set; } = false;
    public int UserId { get; set; }
    public List<BusinessDocument> BusinessDocuments { get; set; } = new List<BusinessDocument>();
    public List<Property> Properties { get; set; } = new List<Property>();
}