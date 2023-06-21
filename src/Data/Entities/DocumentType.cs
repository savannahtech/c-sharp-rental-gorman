using Data.Models;

namespace Data.Entities;

public class DocumentType : BaseEntity
{
    public int DocumentTypeId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Required { get; set; } = false;
}