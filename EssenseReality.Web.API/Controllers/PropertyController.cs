﻿using AutoMapper;
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
        public async Task<IEnumerable<PropertyViewModel>> GetAll()
        {
            var result = await propertyRepository.GelAll();

            var propertyViewModel = mapper.Map<IEnumerable<PropertyViewModel>>(result);

            return propertyViewModel;
        }

        [HttpGet("/{id}")]
        public async Task<PropertyViewModel> Get(int id)
        {
            var result = await propertyRepository.GetByIdAsync(id);

            var propertyViewModel = mapper.Map<PropertyViewModel>(result);

            return propertyViewModel;
        }

        [HttpPut]
        public async Task<PropertyViewModel> Put(PropertyViewModel propertyViewModel)
        {

            var property = mapper.Map<Property>(propertyViewModel);

             await propertyRepository.UpdateAsync(property);

            return mapper.Map<PropertyViewModel>(property);
        }


    }
}