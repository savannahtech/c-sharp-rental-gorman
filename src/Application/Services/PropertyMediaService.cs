using Application.Interfaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Core.Models;
using Core.Pagination;
using Core.Property;
using Data.Context;
using Data.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class PropertyMediaService : IPropertyMediaService
    {
        private readonly RentalContext _rentalContext;
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobService;
        private readonly string _containerName;
        public PropertyMediaService(RentalContext rentalContext, BlobServiceClient blobService, IConfiguration configuration)
        {
            _rentalContext = rentalContext;
            _blobService = blobService;
            _configuration = configuration;
            _containerName = _configuration["BlobContainerName"];
        }

        public async Task CreatePropertyMediaAsync(CreatePropertyMediaModel createPropertyModel)
        {

            var property =
                await _rentalContext.Properties.FirstOrDefaultAsync(c =>
                    c.PropertyId.Equals(createPropertyModel.PropertyId));
            var mediaType =
                await _rentalContext.MediaTypes.FirstOrDefaultAsync(i =>
                    i.MediaTypeId.Equals(createPropertyModel.MediaTypeId));
            if (property == null || mediaType == null)
            {
                throw new FileNotFoundException($"Property not found ");
            }
            
            var container = _blobService.GetBlobContainerClient(_containerName);
            var fileExtension = createPropertyModel.Image.ContentType.Split("/")[1];
            var fileContentType = createPropertyModel.Image.ContentType;
            var fileName = $"{Guid.NewGuid():N}.{fileExtension}";
            
            BlobClient blobClient = container.GetBlobClient(fileName);

            await using (var data = createPropertyModel.Image.OpenReadStream())
            {
              await blobClient.UploadAsync(data, new BlobHttpHeaders{ContentType = fileContentType});
            }

            var media = createPropertyModel.Adapt<PropertyMedia>();
            media.Path = fileName;

            await _rentalContext.PropertyMedias.AddAsync(media);
            await _rentalContext.SaveChangesAsync();
        }        

        public async Task<PageResult<IEnumerable<PropertyMediaModel>>> GetPagePropertyMedia(
            PropertyMediaFilter query)
        {


            var mediaQuery = _rentalContext.PropertyMedias.Include(c => c.MediaType).AsQueryable();

            if (!string.IsNullOrEmpty(query.Type))
            {
                mediaQuery.Where(c => c.MediaType.Name.Equals(query.Type, StringComparison.OrdinalIgnoreCase));
            }

            var result = mediaQuery.Skip(query.PageNumber - 1)
                .Take(query.PageSize).Select(t => new PropertyMediaModel
                {
                    Path = t.Path,
                    Type = t.MediaType.Name
                });

            var count = await mediaQuery.CountAsync();

            return new PageResult<IEnumerable<PropertyMediaModel>>(result,query.PageNumber,query.PageSize, count);
        }

        public async Task RemovePropertMediaAsync(int mediaId)
        {
            var media = await _rentalContext.PropertyMedias.FirstOrDefaultAsync(v => v.PropertyMediaId.Equals(mediaId));
            if (media == null)
            {
                throw new FileNotFoundException($"Property not found ");
            }

            _rentalContext.PropertyMedias.Remove(media);
            await _rentalContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MediaTypeModel>> GetMediaTypesAsync()
        {
            var mediaType = await _rentalContext.MediaTypes.AsQueryable().Select(
                m => m.Adapt<MediaTypeModel>()
            ).ToListAsync();

            return mediaType;
        }
    }
}
