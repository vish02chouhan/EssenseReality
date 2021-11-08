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
using EssenceRealty.Web.API.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : ControllerBase
    {

        private readonly ILogger<PhotoController> _logger;
        private readonly IPhotoRepository PhotoRepository;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment environment;
        private readonly EssenceApiConfig essenceApiConfig;

        public PhotoController(ILogger<PhotoController> logger, IPhotoRepository PhotoRepository,
                                IMapper mapper, IOptions<EssenceApiConfig> config, IWebHostEnvironment environment)
        {
            _logger = logger;
            this.PhotoRepository = PhotoRepository;
            this.mapper = mapper;
            this.environment = environment;
            essenceApiConfig = config.Value;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EssenceResponse<PhotoViewModel>>> Post(List<IFormFile> files,int PropertyId)
        {
            long size = files.Sum(f => f.Length);
            List<PhotoViewModel> lstPhotoViewModel = new();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {

                    PhotoViewModel photoViewModel = await ImageProcessor.ProcessPropertyImage(formFile, PropertyId, essenceApiConfig, environment);

                    lstPhotoViewModel.Add(photoViewModel);
                }
            }
            var lstPhoto = mapper.Map<List<Photo>>(lstPhotoViewModel);

            await PhotoRepository.AddPhotos(lstPhoto);

            return Ok(new EssenceResponse<IEnumerable<PhotoViewModel>>
            {
                Data = mapper.Map<List<PhotoViewModel>>(lstPhoto)
            });
        }

        [HttpDelete]
        [Authorize]
        public async Task Delete(PhotoViewModel photoViewModel)
        {
            var mainPhotoPath = photoViewModel.Url.Replace(essenceApiConfig.ServerUrl, environment.WebRootPath);
            if (System.IO.File.Exists(mainPhotoPath))
            {
                System.IO.File.Delete(mainPhotoPath);
            }

            var thumb1024PhotoPath = photoViewModel.Thumb1024.Replace(essenceApiConfig.ServerUrl, environment.WebRootPath);
            if (System.IO.File.Exists(thumb1024PhotoPath))
            {
                System.IO.File.Delete(thumb1024PhotoPath);
            }

            var thumb180PhotoPath = photoViewModel.Thumb180.Replace(essenceApiConfig.ServerUrl, environment.WebRootPath);

            if (System.IO.File.Exists(thumb180PhotoPath))
            {
                System.IO.File.Delete(thumb180PhotoPath);
            }
            var photo = mapper.Map<Photo>(photoViewModel);
            await PhotoRepository.DeleteAsync(photo);
            
        }
    }
}
