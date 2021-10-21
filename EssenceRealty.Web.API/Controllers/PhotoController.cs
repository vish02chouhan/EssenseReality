using AutoMapper;
using EssenceRealty.Repository.IRepositories;
using EssenceRealty.Domain.ViewModels;
using EssenceRealty.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EssenceRealty.Domain.Exceptions;
using EssenceRealty.Web.API.Model;
using Microsoft.AspNetCore.Http;
using System.IO;
using AutoMapper.Configuration;
using Microsoft.Extensions.Options;
using System.Drawing;

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : ControllerBase
    {

        private readonly ILogger<PhotoController> _logger;
        private readonly IPhotoRepository PhotoRepository;
        private readonly IMapper mapper;
        private readonly ERConfiguration _config;

        public PhotoController(ILogger<PhotoController> logger, IPhotoRepository PhotoRepository,
                                IMapper mapper, IOptions<ERConfiguration> config)
        {
            _logger = logger;
            this.PhotoRepository = PhotoRepository;
            this.mapper = mapper;
            _config = config.Value;
        }

        [HttpPost]
        public async Task<ActionResult<EssenceResponse<PhotoViewModel>>> Post(List<IFormFile> files,int PropertyId)
        {
            long size = files.Sum(f => f.Length);
            List<PhotoViewModel> lstPhotoViewModel = new();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var extension = Path.GetExtension(formFile.FileName);

                    var imageId = Guid.NewGuid().ToString().Replace("-", "");

                    string imageName = $"{imageId}{extension}";

                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\properties", PropertyId.ToString());
                    //var path = Path.Combine(@"/Users/vivekverma/Documents/ER_Photos", PropertyId.ToString());

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var filePath = Path.Combine(path , imageName);

                    int imageWidth, imageHeight = 0;
                    using (var stream = System.IO.File.Create(filePath)) {
                      
                        await formFile.CopyToAsync(stream);
                    
                    }

                    using var image = Image.FromStream(formFile.OpenReadStream());
                    imageWidth = image.Width;
                    imageHeight = image.Height;

                    var thumb1024 = image.GetThumbnailImage(963, 558, () => false, IntPtr.Zero);
                    var thumb1024FilePath = Path.Combine(path, "thumb1024" + imageName);
                    thumb1024.Save(thumb1024FilePath);

                    var thumb180 = image.GetThumbnailImage(180, 104, () => false, IntPtr.Zero);
                    var thumb180FilePath = Path.Combine(path, "thumb180" + imageName);
                    thumb180.Save(thumb180FilePath);

                    PhotoViewModel photoViewModel = new()
                    {
                        Filesize =(int)formFile.Length,
                        Height = imageHeight,
                        Width = imageWidth,
                        Published = true,
                        Type = formFile.ContentType,
                        Filename = imageName,
                        UserFilename = formFile.FileName,
                        Thumb1024 = thumb1024FilePath,
                        Id = 0,
                        PropertyId = PropertyId,
                        Thumb180 = thumb180FilePath,
                        Url = filePath
                    };
                    lstPhotoViewModel.Add(photoViewModel);
                }
            }
            var lstPhoto = mapper.Map<List<Photo>>(lstPhotoViewModel);

            lstPhoto.ForEach(x =>
            {
               x.CrmPhotoId = 0;
                x.ThumbnailId = 0;
            });

            await PhotoRepository.AddPhotos(lstPhoto);

            return Ok(new EssenceResponse<IEnumerable<PhotoViewModel>>
            {
                Data = mapper.Map<List<PhotoViewModel>>(lstPhoto)
            });
        }
    }
}
