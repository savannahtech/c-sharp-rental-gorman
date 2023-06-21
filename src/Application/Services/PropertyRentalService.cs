using Application.Interfaces;
using Core.Models;
using Core.Property;
using Data.Context;
using Data.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PropertyRentalService : IPropertyRentalService
    {
        
        private readonly RentalContext _rentalContext;
        public PropertyRentalService(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task AddPropertyRentalAsync(long reference, AddOrUpdatePropertyRentalModel model)
        {
            var property = await _rentalContext.Properties.FirstOrDefaultAsync(r => r.Reference.Equals(reference));
            if (property == null)
            {
                throw new FileNotFoundException($"Property not found ");
            }

            var propertyRental = model.Adapt<PropertyRental>();
            propertyRental.Amount = model.Rent;
            propertyRental.PropertyId= property.PropertyId;

            await _rentalContext.PropertyRentals.AddAsync(propertyRental);
            await _rentalContext.SaveChangesAsync();

        }

        public async Task UpdatePropertyRentalAsync(int rentalId, AddOrUpdatePropertyRentalModel model)
        {
            var propertyRental = await _rentalContext.PropertyRentals.FirstOrDefaultAsync(r => r.PropertyRentalId.Equals(rentalId));
            if (propertyRental == null)
            {
                throw new FileNotFoundException($"Property Rental not found ");
            }

            var updatedPropertyRetantal = model.Adapt<AddOrUpdatePropertyRentalModel, PropertyRental>(propertyRental);
            updatedPropertyRetantal.Amount = model.Rent;

            _rentalContext.Entry(updatedPropertyRetantal).State = EntityState.Modified;
            await _rentalContext.SaveChangesAsync();
        }

        public async Task RemovePropertyRentalAsync(int rentalId)
        {
            var propertyRental = await _rentalContext.PropertyRentals.FirstOrDefaultAsync(r => r.PropertyRentalId.Equals(rentalId));
            if (propertyRental == null)
            {
                throw new FileNotFoundException($"Property Rental not found ");
            }

            _rentalContext.PropertyRentals.Remove(propertyRental);
            await _rentalContext.SaveChangesAsync();
        }

        public async Task<PropertyRentModel> GetPropertyRentalAsync(int rentalId)
        {

            var propertyRent =
                await _rentalContext.PropertyRentals.FirstOrDefaultAsync(f => f.PropertyRentalId.Equals(rentalId));
            if (propertyRent == null)
            {
                return null;
            }

            var result = propertyRent.Adapt<PropertyRentModel>();

            return result;
        }

        public async Task<IEnumerable<PropertyLetTypeModel>> GetPropertyLetTypesAsync()
        {
            var propertyLetTypes = await _rentalContext.PropertyLetTypes.AsQueryable().
                Select( i =>  i.Adapt<PropertyLetTypeModel>()).
                ToListAsync();

            return propertyLetTypes;
        }
        
        
    }
}
