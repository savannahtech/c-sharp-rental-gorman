

using Data.Models;

namespace Data.Entities;

public class MediaType : BaseEntity
{
    public int MediaTypeId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
}