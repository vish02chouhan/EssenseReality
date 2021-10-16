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
    public class PropertyClassController : ControllerBase
    {

        private readonly ILogger<PropertyClassController> _logger;
        private readonly IPropertyRepository propertyRepository;
        private readonly IMapper mapper;

        public PropertyClassController(ILogger<PropertyClassController> logger, IPropertyRepository propertyRepository,
            IMapper mapper)
        {
            _logger = logger;
            this.propertyRepository = propertyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<IEnumerable<PropertyClassViewModel>>>> Get()
        {
            var result = await propertyRepository.GelAll();

            var propertyClassViewModel = mapper.Map<IEnumerable<PropertyClassViewModel>>(result);

            return Ok(new EssenceResponse<IEnumerable<PropertyClassViewModel>>
            {
                Data = propertyClassViewModel
            }); ;
        }
    }
}
