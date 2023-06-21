using Application.Interfaces;
using Core.Property;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/property/media")]
    public class PropertyMediaController : ControllerBase
    {
        private readonly IPropertyMediaService _propertyMediaService;

        public PropertyMediaController(IPropertyMediaService propertyMediaService)
        {
            _propertyMediaService = propertyMediaService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMedia(CreatePropertyMediaModel request)
        {

            //check for file size
            if ((request.Image.Length / 1048576.0) > 10)
            {
                return BadRequest("File size is should be less than  10MB ");
            }
            
            var fileType = request.Image.ContentType.Split("/")[0];
            if ( !fileType.Equals( "image",StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Please upload only images");
            }

             
            await _propertyMediaService.CreatePropertyMediaAsync(request);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetImages([FromQuery] PropertyMediaFilter filter)
        {
            var result = await _propertyMediaService.GetPagePropertyMedia(filter);

            return Ok(result);
        }


        [HttpGet("MediaTypes")]
        public async Task<IActionResult> GetMediaTypes()
        {
            var result = await _propertyMediaService.GetMediaTypesAsync();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMedia(int mediaId)
        {
            await _propertyMediaService.RemovePropertMediaAsync(mediaId);
            return Ok();
        }
    }
}