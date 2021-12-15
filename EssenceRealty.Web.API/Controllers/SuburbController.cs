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
    public class SuburbController : ControllerBase
    {

        private readonly ILogger<SuburbController> _logger;
        private readonly ISubhurbRepository subhurbRepository;
        private readonly IMapper mapper;

        public SuburbController(ILogger<SuburbController> logger, ISubhurbRepository subhurbRepository,
            IMapper mapper)
        {
            _logger = logger;
            this.subhurbRepository = subhurbRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<IEnumerable<SuburbViewModel>>>> Get()
        {
            var result = await subhurbRepository.ListAllAsync();

            return Ok(new EssenceResponse<IEnumerable<SuburbViewModel>>
            {
                Data = mapper.Map<IEnumerable<SuburbViewModel>>(result)
            });
        }

        [HttpGet]
        [Route("GetSuburbByStateId")]
        public async Task<ActionResult<EssenceResponse<IEnumerable<SuburbViewModel>>>> GetSuburbByStateId(int stateId)
        {
            var result = await subhurbRepository.GetSuburbByStateId(stateId);

            return Ok(new EssenceResponse<IEnumerable<SuburbViewModel>>
            {
                Data = mapper.Map<IEnumerable<SuburbViewModel>>(result)
            });
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<EssenceResponse<IEnumerable<SuburbViewModel>>>> Get(int pageNumber, int pageSize)
        {
            var suburbsCount = await subhurbRepository.GetCount();
            var result = await subhurbRepository.GetPagedReponseAsync(pageNumber, pageSize);

            return Ok(new EssencePaginationResponse<IEnumerable<SuburbViewModel>>
            {
                Data = mapper.Map<IEnumerable<SuburbViewModel>>(result), 
                TotalCount =  suburbsCount
            });
        }
    }
}
