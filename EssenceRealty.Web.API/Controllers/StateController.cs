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
        public async Task<ActionResult<EssenceResponse<IEnumerable<StateViewModel>>>> Get()
        {
            var result = await stateRepository.ListAllAsync();

            return Ok(new EssenceResponse<IEnumerable<StateViewModel>>
            {
                Data = mapper.Map<IEnumerable<StateViewModel>>(result)
            });
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<EssenceResponse<IEnumerable<StateViewModel>>>> Get(int pageNumber, int pageSize)
        {
            var result = await stateRepository.GetPagedReponseAsync(pageNumber, pageSize);

            return Ok(new EssenceResponse<IEnumerable<StateViewModel>>
            {
                Data = mapper.Map<IEnumerable<StateViewModel>>(result)
            });
        }

    }
}
