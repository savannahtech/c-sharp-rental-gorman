using Application.Interfaces;
using Core.Property;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/property/listing")]
    public class PropertyListingController : ControllerBase
    {
        private readonly IPropertyListingService _propertyListingService;

        public PropertyListingController(IPropertyListingService propertyListingService)
        {
            _propertyListingService = propertyListingService;
        }


        /// <summary>
        ///  Create Property 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromBody] AddOrUpdatePropertyModel request)
        {
            await _propertyListingService.CreatePropertyAsync(request);
            return Ok();
        }


        /// <summary>
        /// Get paginated list of Properties 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProperty([FromQuery] PropertyFilter request)
        {
            var properties = await _propertyListingService.GetPagedProperty(request);

            
            return Ok(properties);
        }

        
        /// <summary>
        /// Get property Details 
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>

        [HttpGet("{reference}")]
        public async Task<IActionResult> GetProperty(long reference)
        {
            var property = await _propertyListingService.GetPropertyAsync(reference);

            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        /// <summary>
        ///  update property
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{reference}")]
        public async Task<IActionResult> UpdateProperty(long reference, AddOrUpdatePropertyModel request)
        {

            await _propertyListingService.UpdatePropertyModelAsync(reference, request);

            return Ok();
            
        }
        
        
        /// <summary>
        ///  Delete Property 
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>

        [HttpDelete("{reference}")]
        public async Task<IActionResult> DeleteProperty(long reference)
        {
            await _propertyListingService.RemovePropertyAsync(reference);

            return Ok();
        }


        [HttpGet("featureType")]
        public async Task<IActionResult> GetFeatureType()
        {
            var featureTypes = await _propertyListingService.GetFeatureTypesAsync();

            return Ok(featureTypes);
        }

    }
}