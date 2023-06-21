using Application.Interfaces;
using Core.Models;
using Core.Pagination;
using Core.Property;
using Data.Context;
using Data.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PropertyViewService : IPropertyViewService
    {
        private readonly RentalContext _rentalContext;
        public PropertyViewService(RentalContext rentalContext)
        {
            _rentalContext = rentalContext;
        }

        public async Task AddPropertyViewAsync(long reference, CreatePropertyViewModel model)
        {

            var property = await _rentalContext.Properties.FirstOrDefaultAsync(i => i.Reference.Equals(reference));
            if ( property == null)
            {
                throw new FileNotFoundException($"Property not found ");
            }
            
            var propertyView = model.Adapt<PropertyView>();
            propertyView.PropertyId = property.PropertyId;
            await  _rentalContext.PropertyViews.AddAsync(propertyView);
            await _rentalContext.SaveChangesAsync();
        }

        public async Task<PageResult<IEnumerable<PropertyViewModel>>> GetPagePropertyViewAsync(
            long reference, int pageNumber, int pageSize)
        {

            var propertyViews = _rentalContext.PropertyViews
                .Include( i => i.Property).AsQueryable();

            var data = await propertyViews.Where(p => p.Property.Reference.Equals(reference)).
                Skip(pageNumber - 1)
                .Take(pageSize)
                . Select( i => i.Adapt<PropertyViewModel>())
                .ToListAsync();
            var count = await propertyViews.CountAsync();
            
            return new PageResult<IEnumerable<PropertyViewModel>>(data, pageNumber, pageSize,count);

        }

        public async Task<PropertyViewModel> GetPropertyViewAsync(int viewId)
        {
            var propertyView =
                await _rentalContext.PropertyViews.FirstOrDefaultAsync(i => i.PropertyViewId.Equals(viewId));
            if (propertyView == null)
            {
                return null;
            }

            return propertyView.Adapt<PropertyViewModel>();
        }

        public async Task RemovePropertyViewAsync(int viewId)
        {
            var propertyView =
                await _rentalContext.PropertyViews.FirstOrDefaultAsync(i => i.PropertyViewId.Equals(viewId));
            if (propertyView == null)
            {
                throw new FileNotFoundException($"Property view found ");
            }

            _rentalContext.PropertyViews.Remove(propertyView);
            await _rentalContext.SaveChangesAsync();
        }
    }
}
