using Application.Services;
using Data.Context;
using Unit.Test.Configurations;

namespace Unit.Test.Services;

public class PropertyListingServiceTest : TestWithSqlite
{
    private readonly PropertyListingService _propertyListingService;
    public PropertyListingServiceTest()
    {
       // _propertyListingService = new PropertyListingService(_rentalContext);
    }   
    
    
}