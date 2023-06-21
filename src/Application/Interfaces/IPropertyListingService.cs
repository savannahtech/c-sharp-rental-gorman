using Core.Models;
using Core.Pagination;
using Core.Property;

namespace Application.Interfaces
{
    public interface IPropertyListingService
    {
        Task<long> CreatePropertyAsync(AddOrUpdatePropertyModel createPropertyModel);

        Task<PageResult<IEnumerable<PropertyModel>>> GetPagedProperty(PropertyFilter query);
        Task<PropertyModel> GetPropertyAsync(long reference);
        Task ListPropertyAsync(long reference);
        Task RemovePropertyAsync(long reference);
        Task UpdatePropertyModelAsync(long reference, AddOrUpdatePropertyModel updatePropertyModel);
        Task<IEnumerable<FeatureTypeModel>> GetFeatureTypesAsync();
    }
}
