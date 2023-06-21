using Core.Models;
using Core.Property;

namespace Application.Interfaces
{
    public interface IPropertySaleService
    {
        Task AddPropertySaleAsync(long reference, AddOrUpdatePropertySaleModel model);
        Task UpdatePropertySaleAsync(int saleId, AddOrUpdatePropertySaleModel model);
        Task RemovePropertySaleAsync(int saleId);
        Task<PropertySaleModel> GetPropertySaleAsync(long saleId);
        Task<IEnumerable<PropertyTenureTypeModel>> GetPropertyTenuresAsync();
    }
}
