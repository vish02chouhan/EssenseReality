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
        public async Task<IEnumerable<SuburbViewModel>> Get()
        {
            var result = await subhurbRepository.ListAllAsync();

            var suburbViewModel = mapper.Map<IEnumerable<SuburbViewModel>>(result);

            return suburbViewModel;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IEnumerable<SuburbViewModel>> Get(int pageNumber, int pageSize)
        {
            var result = await subhurbRepository.GetPagedReponseAsync(pageNumber, pageSize);

            var suburbViewModel = mapper.Map<IEnumerable<SuburbViewModel>>(result);

            return suburbViewModel;
        }
    }
}
