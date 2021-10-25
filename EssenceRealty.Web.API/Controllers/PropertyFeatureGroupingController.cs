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
    public class PropertyFeatureGroupingController : ControllerBase
    {

        private readonly ILogger<PropertyFeatureGroupingController> _logger;
        private readonly IPropertyFeatureGroupingRepository propertyFeatureGroupingRepository;
        private readonly IMapper mapper;

        public PropertyFeatureGroupingController(ILogger<PropertyFeatureGroupingController> logger, IPropertyFeatureGroupingRepository propertyFeatureGroupingRepository,
            IMapper mapper)
        {
            _logger = logger;
            this.propertyFeatureGroupingRepository = propertyFeatureGroupingRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<IEnumerable<PropertyFeatureGroupingViewModel>>>> Get()
        {
            var result = await propertyFeatureGroupingRepository.ListAllAsync();

            return Ok(new EssenceResponse<IEnumerable<PropertyFeatureGroupingViewModel>>
            {
                Data = mapper.Map<IEnumerable<PropertyFeatureGroupingViewModel>>(result)
            });
        }
    }
}
