using Data.Models;

namespace Data.Entities;

public class PropertyMedia : BaseEntity
{
    public int PropertyMediaId { get; set; }
    public string Path { get; set; }
    public string Description { get; set; }
    public int MediaTypeId { get; set; }
    public MediaType MediaType { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
}