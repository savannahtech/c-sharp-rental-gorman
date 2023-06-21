using Core.Models;
using Core.Pagination;
using Core.Property;

namespace Application.Interfaces
{
    public interface IPropertyViewService
    {
        Task AddPropertyViewAsync(long reference, CreatePropertyViewModel model);
        Task<PageResult<IEnumerable<PropertyViewModel>>> GetPagePropertyViewAsync(long reference, int pageNumber, int pageSize);
        Task<PropertyViewModel> GetPropertyViewAsync(int viewId);
        Task RemovePropertyViewAsync(int viewId);
    }
}
