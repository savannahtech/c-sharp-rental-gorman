using Application.Interfaces;
using Core.Models;
using Core.Property;
using Data.Context;
using Data.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PropertySaleService : IPropertySaleService
    {

        private readonly RentalContext _rentalContext;
        public PropertySaleService(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task AddPropertySaleAsync(long reference, AddOrUpdatePropertySaleModel model)
        {


            var property = await _rentalContext.Properties.FirstOrDefaultAsync(i => i.Reference.Equals(reference));

            if (property == null)
            {
                throw new FileNotFoundException($"Property sale not found ");
            }
            
            var propertySale = model.Adapt<PropertySale>();
            await _rentalContext.PropertySales.AddAsync(propertySale);
            await _rentalContext.SaveChangesAsync();

        }

        public async Task UpdatePropertySaleAsync(int saleId, AddOrUpdatePropertySaleModel model)
        {
            var propertySale =
                await _rentalContext.PropertySales.FirstOrDefaultAsync(i => i.PropertySaleId.Equals(saleId));
            if (propertySale == null)
            {
                throw new FileNotFoundException($"Property sale not found ");
            }

            var updatedpropertySale = model.Adapt<AddOrUpdatePropertySaleModel, PropertySale>(propertySale);

            _rentalContext.Entry(updatedpropertySale).State = EntityState.Modified;
            await _rentalContext.SaveChangesAsync();
        }

        public async Task RemovePropertySaleAsync(int saleId)
        {
            var propertySale =
                await _rentalContext.PropertySales.FirstOrDefaultAsync(i => i.PropertySaleId.Equals(saleId));
            if (propertySale == null)
            {
                throw new FileNotFoundException($"Property sale not found ");
            }

            _rentalContext.PropertySales.Remove(propertySale);
            await _rentalContext.SaveChangesAsync();
        }

        public async Task<PropertySaleModel> GetPropertySaleAsync(long saleId)
        {
            var propertySale =
                await _rentalContext.PropertySales.FirstOrDefaultAsync(i => i.PropertySaleId.Equals(saleId));
            if (propertySale == null)
            {
                return null;
            }

            return propertySale.Adapt<PropertySaleModel>();
        }

        public async Task<IEnumerable<PropertyTenureTypeModel>> GetPropertyTenuresAsync()
        {
            var propertyTenures = await _rentalContext.PropertyTenureTypes.AsQueryable()
                .Select(i => i.Adapt<PropertyTenureTypeModel>()).ToListAsync();
            return propertyTenures;
        }
    }
}
