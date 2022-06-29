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
    public class FeedbackController : ControllerBase
    {

        private readonly ILogger<FeedbackController> _logger;
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IMapper mapper;

        public FeedbackController(ILogger<FeedbackController> logger, IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _logger = logger;
            this.feedbackRepository = feedbackRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<EssenceResponse<IEnumerable<FeedbackViewModel>>>> Post(FeedbackViewModel feedbackViewModel)
        {
            var feedback = mapper.Map<Feedback>(feedbackViewModel);

            await  feedbackRepository.AddAsync(feedback);

            var feedbackViewModelResult = mapper.Map<FeedbackViewModel>(feedback);

            return Ok(new EssenceResponse<FeedbackViewModel>
            {
                Data = feedbackViewModelResult,
                Message = new List<string> { "Feedback Saved successfully" }
            });
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<IEnumerable<FeedbackViewModel>>>> Get()
        {
            var result = await feedbackRepository.ListAllAsync();

            return Ok(new EssenceResponse<IEnumerable<FeedbackViewModel>>
            {
                Data = mapper.Map<IEnumerable<FeedbackViewModel>>(result)
            });
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<EssenceResponse<IEnumerable<FeedbackViewModel>>>> Get(int pageNumber, int pageSize)
        {
            var result = await feedbackRepository.GetPagedReponseAsync(pageNumber, pageSize);

            return Ok(new EssenceResponse<IEnumerable<FeedbackViewModel>>
            {
                Data = mapper.Map<IEnumerable<FeedbackViewModel>>(result)
            });
        }

    }
}
