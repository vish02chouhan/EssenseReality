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
    public class CountryController : ControllerBase
    {

        private readonly ILogger<CountryController> _logger;
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountryController(ILogger<CountryController> logger, ICountryRepository countryRepository,
            IMapper mapper)
        {
            _logger = logger;
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<IEnumerable<CountryViewModel>>>> Get()
        {
            var result = await countryRepository.ListAllAsync();

            var countryViewModel = mapper.Map<IEnumerable<CountryViewModel>>(result);

            return Ok(new EssenceResponse<IEnumerable<CountryViewModel>>
            {
                Data = countryViewModel
            });
        }
    }
}
