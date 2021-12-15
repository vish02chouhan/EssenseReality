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

            var propertyViewModel = mapper.Map<IEnumerable<PropertyViewModel>>(result);

            return Ok(new EssenceResponse<IEnumerable<PropertyViewModel>>
            {
                Data = propertyViewModel
            });
        }


        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<EssenceResponse<EnquiryViewModel>>> GetAll(int pageNumber, int pageSize)
        {
            var propertyCount = await propertyRepository.GetCount();
            var result = await propertyRepository.GetPagedReponseAsync(pageNumber, pageSize);
            var propertyViewModel = mapper.Map<IEnumerable<PropertyViewModel>>(result);

            return Ok(new EssencePaginationResponse<IEnumerable<PropertyViewModel>>
            {
                Data = propertyViewModel,
                TotalCount = propertyCount
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

        [HttpPost("search/{pageNumber}/{pageSize}")]
        public async Task<ActionResult<EssencePaginationResponse<PropertyViewModel>>> Post(int pageNumber, int pageSize,PropertySearchRequest propertySearchRequest)
        {
            var result = await propertyRepository.SearchAsync(propertySearchRequest, pageNumber, pageSize);

            var propertyViewModel = mapper.Map<IEnumerable<PropertyViewModel>>(result.Item1);

            return Ok(new EssencePaginationResponse<IEnumerable<PropertyViewModel>>
            {
                Data = propertyViewModel,
                TotalCount = result.Item2
            });


        }

    }

}
