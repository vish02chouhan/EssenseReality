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
using EssenceRealty.Web.API.Model;

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyTypeController : ControllerBase
    {

        private readonly ILogger<PropertyTypeController> _logger;
        private readonly IPropertyTypeRepository propertyTypeRepository;
        private readonly IMapper mapper;

        public PropertyTypeController(ILogger<PropertyTypeController> logger, IPropertyTypeRepository propertyTypeRepository, IMapper mapper)
        {
            _logger = logger;
            this.propertyTypeRepository = propertyTypeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<IEnumerable<PropertyTypeViewModel>>>> GetAll()
        {
            var result = await propertyTypeRepository.ListAllAsync();

            var propertyViewModel = mapper.Map<IEnumerable<PropertyTypeViewModel>>(result);

            return Ok(new EssenceResponse<IEnumerable<PropertyTypeViewModel>>
            {
                Data = propertyViewModel
            });
        }

        [HttpGet("propertyclass/{id}")]
        public async Task<ActionResult<EssenceResponse<IEnumerable<PropertyTypeViewModel>>>> Get(int id)
        {
            var result = await propertyTypeRepository.GetManyAsync(x=> x.PropertyClass.Id == id);

            var propertyViewModel = mapper.Map<IEnumerable<PropertyTypeViewModel>>(result);

            return Ok(new EssenceResponse<IEnumerable<PropertyTypeViewModel>>
            {
                Data = propertyViewModel
            });
        }
    }
}
