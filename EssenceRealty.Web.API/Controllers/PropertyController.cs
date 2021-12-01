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
using Microsoft.AspNetCore.Authorization;

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {

        private readonly ILogger<PropertyController> _logger;
        private readonly IPropertyRepository propertyRepository;
        private readonly IPhotoRepository photoRepository;
        private readonly IMapper mapper;

        public PropertyController(ILogger<PropertyController> logger, IPropertyRepository propertyRepository,
           IPhotoRepository photoRepository, IMapper mapper)
        {
            _logger = logger;
            this.propertyRepository = propertyRepository;
            this.photoRepository = photoRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<IEnumerable<PropertyViewModel>>>> GetAll()
        {
            var result = await propertyRepository.GelAll();

            var result1 = await photoRepository.GetByIdAsync(1);

            var propertyViewModel = mapper.Map<IEnumerable<PropertyViewModel>>(result);

            return Ok(new EssenceResponse<IEnumerable<PropertyViewModel>>
            {
                Data = propertyViewModel
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EssenceResponse<PropertyViewModel>>> Get(int id)
        {
            var property = await propertyRepository.GetByIdAsync(id);

            if(property == null)
            {
                throw new NotFoundException(nameof(Property), id);
            }

            return Ok(new EssenceResponse<PropertyViewModel>
            {
                Data = mapper.Map<PropertyViewModel>(property)
            });
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<EssenceResponse<PropertyViewModel>>> Put(PropertyViewModel propertyViewModel)
        {

            Property property = mapper.Map<Property>(propertyViewModel);
            
            var objProperty = await propertyRepository.UpdateProperty(property);

            return Ok(new EssenceResponse<PropertyViewModel>
            {
                Data = mapper.Map<PropertyViewModel>(objProperty)
            });
        }

        [HttpPost("search")]
        public async Task<ActionResult<EssenceResponse<PropertyViewModel>>> Post(PropertySearchRequest propertySearchRequest)
        {
            var result = await propertyRepository.SearchAsync(propertySearchRequest);

            var propertyViewModel = mapper.Map<IEnumerable<PropertyViewModel>>(result);

            return Ok(new EssenceResponse<IEnumerable<PropertyViewModel>>
            {
                Data = propertyViewModel
            });


        }

    }

}
