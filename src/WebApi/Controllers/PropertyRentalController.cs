using Application.Interfaces;
using Core.Property;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/property/rental")]
    public class PropertyRentalController : ControllerBase
    {
        private readonly IPropertyRentalService _propertyRentalService;
        public PropertyRentalController(IPropertyRentalService propertyRentalService)
        {
            _propertyRentalService = propertyRentalService;
        }


        [HttpPost("{reference}")]
        public async Task<IActionResult> CreateRental( long reference ,[FromBody]AddOrUpdatePropertyRentalModel request)
        {
            await _propertyRentalService.AddPropertyRentalAsync(reference, request);

           return Ok();
        }


        [HttpGet("{rentalId}")]
        public async Task<IActionResult> GetRental(int rentalId)
        {

            var rental = await _propertyRentalService.GetPropertyRentalAsync(rentalId);

            if ( rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }
        
        [HttpPut("{rentalId}")]
        public async Task<IActionResult> UpdateRental(int rentalId, AddOrUpdatePropertyRentalModel request)
        {
            await _propertyRentalService.UpdatePropertyRentalAsync(rentalId, request);

            return Ok();
        }

        [HttpDelete("{rentalId}")]
        public async Task<IActionResult> DeleteRental(int rentalId)
        {
            await _propertyRentalService.RemovePropertyRentalAsync(rentalId);
            return Ok();
        }

        [HttpGet("LetTypes")]
        public async Task<IActionResult> GetLetTypes()
        {
            var letTypes = await _propertyRentalService.GetPropertyLetTypesAsync();

            return Ok(letTypes);
        }
    }
}
