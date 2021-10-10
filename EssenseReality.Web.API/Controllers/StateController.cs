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
    public class StateController : ControllerBase
    {

        private readonly ILogger<StateController> _logger;
        private readonly IStateRepository stateRepository;
        private readonly IMapper mapper;

        public StateController(ILogger<StateController> logger, IStateRepository stateRepository,
            IMapper mapper)
        {
            _logger = logger;
            this.stateRepository = stateRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StateViewModel>> Get()
        {
            var result = await stateRepository.ListAllAsync();

            var stateViewModel = mapper.Map<IEnumerable<StateViewModel>>(result);

            return stateViewModel;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IEnumerable<StateViewModel>> Get(int pageNumber, int pageSize)
        {
            var result = await stateRepository.GetPagedReponseAsync(pageNumber, pageSize);

            var stateViewModel = mapper.Map<IEnumerable<StateViewModel>>(result);

            return stateViewModel;
        }
    }
}
