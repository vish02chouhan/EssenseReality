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

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FloorPlanController : ControllerBase
    {

        private readonly ILogger<FloorPlanController> logger;
        private readonly IFloorPlanRepository floorPlanRepository;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment environment;
        private readonly EssenceApiConfig essenceApiConfig;

        public FloorPlanController(ILogger<FloorPlanController> logger, IFloorPlanRepository floorPlanRepository, IMapper mapper, IOptions<EssenceApiConfig> options, IWebHostEnvironment environment)
        {
            this.logger = logger;
            this.floorPlanRepository = floorPlanRepository;
            this.mapper = mapper;
            this.environment = environment;
            essenceApiConfig = options.Value;
        }

        [HttpPost]
        public async Task<ActionResult<EssenceResponse<FloorPlanViewModel>>> Post(List<IFormFile> files,int propertyId, string description)
        {
           var existingFloorPlan = await  floorPlanRepository.GetByPropertyIdAsync(propertyId);

            if(existingFloorPlan != null)
            {
                throw new BadHttpRequestException("Floor plan already exists for property", propertyId);
            }

            var size = files.Sum(f => f.Length);
            List<FloorPlanFilesViewModel> floorPlanFilesViewModels = new();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {

                    var floorPlanFilesViewModel = await ImageProcessor.ProcessFloorPlanFile(formFile, propertyId, essenceApiConfig, environment);

                    floorPlanFilesViewModels.Add(floorPlanFilesViewModel);
                }
            }
            var floorPlanFIles = mapper.Map<List<FloorPlanFile>>(floorPlanFilesViewModels);

            var floorPlan = new FloorPlan
            {
                Description = description,
                FloorPlanFiles = floorPlanFIles,
                PropertyId = propertyId

            };

            await floorPlanRepository.AddFloorPlan(floorPlan);

            return Ok(new EssenceResponse<FloorPlanViewModel>
            {
                Data = mapper.Map<FloorPlanViewModel>(floorPlan)
            });
        }

        [HttpDelete]
        public async Task Delete(int id)
        {

            var floorPlan = await floorPlanRepository.GetByIdAsync(id);

            if (floorPlan == null)
            {
                throw new BadHttpRequestException("Floor plan does not exists", id);
            }
            foreach (var item in floorPlan.FloorPlanFiles)
            {
                var mainPhotoPath = item.Url.Replace(essenceApiConfig.ServerUrl, environment.WebRootPath);
                if (System.IO.File.Exists(mainPhotoPath))
                {
                    System.IO.File.Delete(mainPhotoPath);
                }
            }

            await floorPlanRepository.DeleteAsync(floorPlan);

        }


        [HttpPut]
        public async Task<ActionResult<EssenceResponse<FloorPlanViewModel>>> Put(List<IFormFile> files, int id, int propertyId, string description)
        {
            var existingFloorPlan = await floorPlanRepository.GetByIdAsync(id);

            var filesToDelete = existingFloorPlan.FloorPlanFiles.Select(x => x.Url);

            if (existingFloorPlan == null)
            {
                throw new NotFoundException(nameof(FloorPlan), propertyId);
            }

            List<FloorPlanFilesViewModel> floorPlanFilesViewModels = new();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {

                    var floorPlanFilesViewModel = await ImageProcessor.ProcessFloorPlanFile(formFile, propertyId, essenceApiConfig, environment);

                    floorPlanFilesViewModels.Add(floorPlanFilesViewModel);
                }
            }
            var floorPlanFIles = mapper.Map<List<FloorPlanFile>>(floorPlanFilesViewModels);


            existingFloorPlan.Description = description;
            existingFloorPlan.FloorPlanFiles.AddRange(floorPlanFIles);
            existingFloorPlan.PropertyId = propertyId;

            await floorPlanRepository.UpdateAsync(existingFloorPlan);

            return Ok(new EssenceResponse<FloorPlanViewModel>
            {
                Data = mapper.Map<FloorPlanViewModel>(existingFloorPlan)
            });
        }
    }
}
