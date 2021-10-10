using AutoMapper;
using EssenceRealty.Repository.IRepositories;
using EssenseReality.Domain.ViewModels;
using EssenseReality.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssenseReality.Web.API.Controllers
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
        public async Task<IEnumerable<PropertyClassViewModel>> GetAll()
        {
            var result = await propertyRepository.GelAll();

            var propertyClassViewModel = mapper.Map<IEnumerable<PropertyClassViewModel>>(result);

            return propertyClassViewModel;
        }
    }
}
