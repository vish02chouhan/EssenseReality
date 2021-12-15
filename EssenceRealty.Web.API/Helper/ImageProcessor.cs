using EssenceRealty.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace EssenceRealty.Web.API.Helper
{
    public static class ImageProcessor
    {

        public static async Task<PhotoViewModel> ProcessPropertyImage(IFormFile formFile, int propertyId, EssenceApiConfig essenceApiConfig, IWebHostEnvironment environment)
        {
            var extension = Path.GetExtension(formFile.FileName);
            var imageId = Guid.NewGuid().ToString().Replace("-", "");
            string imageName = $"{imageId}{extension}";
            var imagePath = Path.Combine( essenceApiConfig.ErImagePath, propertyId.ToString());
            var imageFullPath = Path.Combine(environment.WebRootPath, imagePath);

            if (!Directory.Exists(imageFullPath))
            {
                Directory.CreateDirectory(imageFullPath);
            }

            var filePath = Path.Combine(imageFullPath, imageName);

            using (var stream = File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }

            using var image = Image.FromStream(formFile.OpenReadStream());
            int imageWidth, imageHeight = 0;
            imageWidth = image.Width;
            imageHeight = image.Height;

          
            var thumb1024FilePath = Path.Combine(imageFullPath, essenceApiConfig.Thumb180);
            if (!Directory.Exists(thumb1024FilePath))
            {
                Directory.CreateDirectory(thumb1024FilePath);
            }
            var thumb1024 = image.GetThumbnailImage(963, 558, () => false, IntPtr.Zero);
            var thumb1024FilFullePath = Path.Combine(thumb1024FilePath,imageName);
            thumb1024.Save(thumb1024FilFullePath);

   
            var thumb180FilePath = Path.Combine(imageFullPath, essenceApiConfig.Thumb1024);
            if (!Directory.Exists(thumb180FilePath))
            {
                Directory.CreateDirectory(thumb180FilePath);
            }
            var thumb180 = image.GetThumbnailImage(180, 104, () => false, IntPtr.Zero);
            var thumb180FilFullePath = Path.Combine(thumb180FilePath, imageName);
            thumb180.Save(thumb180FilFullePath);

            var orignalImageUrl = Path.Combine(essenceApiConfig.ServerUrl, imagePath, imageName);
            var thumb1024Url = Path.Combine(essenceApiConfig.ServerUrl, imagePath, essenceApiConfig.Thumb1024, imageName);
            var thumb180Url = Path.Combine(essenceApiConfig.ServerUrl, imagePath, essenceApiConfig.Thumb180, imageName);


            return new()
            {
                Filesize = (int)formFile.Length,
                Height = imageHeight,
                Width = imageWidth,
                Published = true,
                Type = formFile.ContentType,
                Filename = imageName,
                UserFilename = formFile.FileName,
                Thumb1024 = thumb1024Url.Replace("\\","/"),
                Id = 0,
                PropertyId = propertyId,
                Thumb180 = thumb180Url.Replace("\\", "/"),
                Url = orignalImageUrl.Replace("\\", "/"),
            };
        }

        public static async Task<FloorPlanFilesViewModel> ProcessFloorPlanFile(IFormFile formFile, int propertyId, EssenceApiConfig essenceApiConfig, IWebHostEnvironment environment)
        {
            var extension = Path.GetExtension(formFile.FileName);
            var fileId = Guid.NewGuid().ToString().Replace("-", "");
            string fileName = $"{fileId}{extension}";
            var filePath = Path.Combine(essenceApiConfig.ErFilePath, propertyId.ToString());
            var fileDirectoryPath = Path.Combine(environment.WebRootPath, filePath);

            if (!Directory.Exists(fileDirectoryPath))
            {
                Directory.CreateDirectory(fileDirectoryPath);
            }

            var fileFullPath = Path.Combine(fileDirectoryPath, fileName);

            using (var stream = File.Create(fileFullPath))
            {
                await formFile.CopyToAsync(stream);
            }

            return new()
            {
                Filesize = (int)formFile.Length,
                Type = formFile.ContentType,
                Filename = fileName,
                UserFilename = formFile.FileName,
                Url = fileFullPath.Replace(environment.WebRootPath,essenceApiConfig.ServerUrl).Replace("\\", "/"),
            };
        }

        public static async Task<(string,string)> ProcessContactStaffImage(IFormFile formFile, int contactStaffId, EssenceApiConfig essenceApiConfig, IWebHostEnvironment environment)
        {
            var extension = Path.GetExtension(formFile.FileName);
            var imageId = Guid.NewGuid().ToString().Replace("-", "");
            string imageName = $"{imageId}{extension}";
            var imagePath = Path.Combine(essenceApiConfig.ERContactStaffImagePath, contactStaffId.ToString());
            var imageFullPath = Path.Combine(environment.WebRootPath, imagePath);

            if (!Directory.Exists(imageFullPath))
            {
                Directory.CreateDirectory(imageFullPath);
            }

            var filePath = Path.Combine(imageFullPath, imageName);

            using (var stream = File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }

            using var image = Image.FromStream(formFile.OpenReadStream());


            var thumb180FilePath = Path.Combine(imageFullPath, essenceApiConfig.Thumb180);
            if (!Directory.Exists(thumb180FilePath))
            {
                Directory.CreateDirectory(thumb180FilePath);
            }
            var thumb180 = image.GetThumbnailImage(180, 104, () => false, IntPtr.Zero);
            var thumb180FilFullePath = Path.Combine(thumb180FilePath, imageName);
            thumb180.Save(thumb180FilFullePath);

            var orignalImageUrl = Path.Combine(essenceApiConfig.ServerUrl, imagePath, imageName);
            var thumb180Url = Path.Combine(essenceApiConfig.ServerUrl, imagePath, essenceApiConfig.Thumb180, imageName);

            return (thumb180Url.Replace("\\", "/"), orignalImageUrl.Replace("\\", "/"));

        }

    }
}
