using Data.Models;

namespace Data.Entities;

public class BusinessDocument : BaseEntity
{
    public int BusinessDocumentId { get; set; }
    public string Reference { get; set; }   
    public int DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; }
    public int BusinessId  { get; set; }
    public Business Business { get; set; }
}