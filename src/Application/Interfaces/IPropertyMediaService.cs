using Core.Models;
using Core.Pagination;
using Core.Property;

namespace Application.Interfaces
{
    public interface IPropertyMediaService
    {
        Task CreatePropertyMediaAsync(CreatePropertyMediaModel createPropertyModel);
        Task<PageResult<IEnumerable<PropertyMediaModel>>> GetPagePropertyMedia(PropertyMediaFilter query);
        Task<IEnumerable<MediaTypeModel>> GetMediaTypesAsync();
        Task RemovePropertMediaAsync(int mediaId);
    }
}
