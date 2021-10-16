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

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {

        private readonly ILogger<PropertyController> _logger;
        private readonly IPropertyRepository propertyRepository;
        private readonly IMapper mapper;

        public PropertyController(ILogger<PropertyController> logger, IPropertyRepository propertyRepository,
            IMapper mapper)
        {
            _logger = logger;
            this.propertyRepository = propertyRepository;
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
        public async Task<ActionResult<EssenceResponse<PropertyViewModel>>> Put(PropertyViewModel propertyViewModel)
        {

            var property = mapper.Map<Property>(propertyViewModel);

             await propertyRepository.UpdateAsync(property);

            return Ok(new EssenceResponse<PropertyViewModel>
            {
                Data = mapper.Map<PropertyViewModel>(property)
            });
        }
    }
}
