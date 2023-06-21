using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services) 
        {
            services.AddScoped<IPropertyListingService, PropertyListingService>();
            services.AddScoped<IPropertyRentalService, PropertyRentalService>();
            services.AddScoped<IPropertySaleService, PropertySaleService>();
            services.AddScoped<IPropertyViewService, PropertyViewService>();
            services.AddScoped<IPropertyMediaService, PropertyMediaService>();

            return services;
        }
    }
}
