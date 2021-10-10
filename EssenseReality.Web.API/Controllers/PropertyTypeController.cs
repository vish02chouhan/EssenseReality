//using AutoMapper;
//using EssenceRealty.Repository.IRepositories;
//using EssenseReality.Domain.ViewModels;
//using EssenseReality.Domain.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace EssenseReality.Web.API.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class PropertyTypeController : ControllerBase
//    {

//        private readonly ILogger<PropertyTypeController> _logger;
//        private readonly IPropertyTypeRepository propertyTypeRepository;
//        private readonly IMapper mapper;

//        public PropertyTypeController(ILogger<PropertyTypeController> logger, IPropertyTypeRepository propertyTypeRepository, IMapper mapper)
//        {
//            _logger = logger;
//            this.propertyTypeRepository = propertyTypeRepository;
//            this.mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<PropertyTypeViewModel>> GetAll()
//        {
//            var result = await propertyTypeRepository.ListAllAsync();

//            var propertyViewModel = mapper.Map<IEnumerable<PropertyTypeViewModel>>(result);

//            return propertyViewModel;
//        }
//    }
//}
