
using Microsoft.AspNet.Http;

namespace Core.Property
{
    public class CreatePropertyMediaModel
    {
        public int MediaTypeId { get; set; }
        public string Description { get; set; }
        public int PropertyId { get; set; }
        public IFormFile Image { get; set; }
    }
}
