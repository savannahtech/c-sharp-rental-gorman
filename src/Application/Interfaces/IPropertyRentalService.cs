using Core.Models;
using Core.Property;

namespace Application.Interfaces
{
    public interface IPropertyRentalService
    {
        Task AddPropertyRentalAsync(long reference, AddOrUpdatePropertyRentalModel model);
        Task<PropertyRentModel> GetPropertyRentalAsync(int rentalId);
        Task RemovePropertyRentalAsync(int rentalId);
        Task UpdatePropertyRentalAsync(int rentalId, AddOrUpdatePropertyRentalModel model);
        Task<IEnumerable<PropertyLetTypeModel>> GetPropertyLetTypesAsync();
    }
}
