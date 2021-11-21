using System;
using System.Threading;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using UtopiaCity.Models.Business.Temp;
using UtopiaCity.Services.Business.Application;

namespace UtopiaCity.Services.Business.Infrastructure.Cloudinary
{
    public class PictureService: IPictureService
    {
        private readonly CloudinaryDotNet.Cloudinary _cloudinary;
        
        public PictureService(IOptions<CloudinarySettings> settings)
        {
            var account = new Account(
                settings.Value.CloudName, 
                settings.Value.ApiKey, 
                settings.Value.ApiSecret
            );

            _cloudinary = new CloudinaryDotNet.Cloudinary(account);
        }

        public async Task<Picture> AddPicture(IFormFile file)
        {
            if (file.Length > 0)
            {
                await using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill")
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }

                return new Picture
                {
                    PictureId = uploadResult.PublicId,
                    PictureUrl = uploadResult.SecureUrl.ToString()
                };
            }

            return null;
        }

        public async Task DeletePicture(string pictureId, CancellationToken cancellationToken)
        {
            var deleteParams = new DeletionParams(pictureId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}