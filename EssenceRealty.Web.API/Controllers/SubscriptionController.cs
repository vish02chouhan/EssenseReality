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
    public class SubscriptionController : ControllerBase
    {

        private readonly ILogger<SubscriptionController> _logger;
        private readonly ISubscriptionRepository subscriptionRepository;
        private readonly IMapper mapper;

        public SubscriptionController(ILogger<SubscriptionController> logger, ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _logger = logger;
            this.subscriptionRepository = subscriptionRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<EssenceResponse<IEnumerable<SubscriptionViewModel>>>> Post(SubscriptionViewModel feedbackViewModel)
        {
            var subscription = mapper.Map<Subscription>(feedbackViewModel);

            await subscriptionRepository.AddAsync(subscription);

            var feedbackViewModelResult = mapper.Map<SubscriptionViewModel>(subscription);

            return Ok(new EssenceResponse<SubscriptionViewModel>
            {
                Data = feedbackViewModelResult,
                Message = new List<string> { "Subscription Saved successfully" }
            });
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<IEnumerable<SubscriptionViewModel>>>> Get()
        {
            var result = await subscriptionRepository.ListAllAsync();

            return Ok(new EssenceResponse<IEnumerable<SubscriptionViewModel>>
            {
                Data = mapper.Map<IEnumerable<SubscriptionViewModel>>(result)
            });
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<EssenceResponse<IEnumerable<SubscriptionViewModel>>>> Get(int pageNumber, int pageSize)
        {
            var result = await subscriptionRepository.GetPagedReponseAsync(pageNumber, pageSize);

            return Ok(new EssenceResponse<IEnumerable<SubscriptionViewModel>>
            {
                Data = mapper.Map<IEnumerable<SubscriptionViewModel>>(result)
            });
        }

    }
}
