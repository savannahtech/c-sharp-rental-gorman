using Application.Interfaces;
using Core.Property;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/property/sale")]
    public class PropertySaleController : ControllerBase
    {
        private readonly IPropertySaleService _propertySaleService;
        public PropertySaleController(IPropertySaleService propertySaleService)
        {
            _propertySaleService = propertySaleService;
        }

        [HttpPost("reference")]
        public async Task<IActionResult> CreateSales(long reference, AddOrUpdatePropertySaleModel request)
        {
            await _propertySaleService.AddPropertySaleAsync(reference, request);
            return Ok();
        }

        [HttpPut("{saleId}")]
        public async Task<IActionResult> UpdateSale(int saleId, AddOrUpdatePropertySaleModel request)
        {
            await _propertySaleService.UpdatePropertySaleAsync(saleId, request);

            return Ok();
            
        }

        [HttpDelete("{saleId}")]
        public async Task<IActionResult> DeleteSale(int saleId)
        {
            await _propertySaleService.RemovePropertySaleAsync(saleId);
            return Ok();
        }

        [HttpGet("{saleId}")]
        public async Task<IActionResult> GetSale(int saleId)
        {
            var sale = await _propertySaleService.GetPropertySaleAsync(saleId);

            if ( sale == null)
            
            {
                return NotFound();
            }

            return Ok(sale);
        }

        [HttpGet("tenures")]
        public async Task<IActionResult> GetTenures()
        {
            var tenures = await _propertySaleService.GetPropertyTenuresAsync();

            return Ok(tenures);
        }
    }
}
