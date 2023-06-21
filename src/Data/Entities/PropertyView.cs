using Data.Models;

namespace Data.Entities;

public class PropertyView : BaseEntity
{
    public int PropertyViewId { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
}