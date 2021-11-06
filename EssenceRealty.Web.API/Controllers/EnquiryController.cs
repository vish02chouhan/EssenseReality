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
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EnquiryController : ControllerBase
    {

        private readonly ILogger<EnquiryController> _logger;
        private readonly IEnquiryRepository enquiryRepository;
        private readonly IMapper mapper;
        private readonly IHttpClientFactory _clientFactory;
        private readonly EssenceApiConfig essenceApiConfig;
        public EnquiryController(ILogger<EnquiryController> logger, IEnquiryRepository enquiryRepository,
            IMapper mapper, IHttpClientFactory clientFactory, IOptions<EssenceApiConfig> config)
        {
            _logger = logger;
            this.enquiryRepository = enquiryRepository;
            this.mapper = mapper;
            _clientFactory = clientFactory;
            essenceApiConfig = config.Value;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<EssenceResponse<EnquiryViewModel>>> GetAll(int pageNumber, int pageSize)
        {
            var result = await enquiryRepository.GetPagedReponseAsync(pageNumber, pageSize);
            var enquiryViewModel = mapper.Map<IEnumerable<EnquiryViewModel>>(result);

            return Ok(new EssenceResponse<IEnumerable<EnquiryViewModel>>
            {
                Data = enquiryViewModel
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EssenceResponse<EnquiryViewModel>>> Get(int id)
        {
            var result = await enquiryRepository.GetByIdAsync(id);

            var enquiryViewModel = mapper.Map<EnquiryViewModel>(result);

            return Ok(new EssenceResponse<EnquiryViewModel>
            {
                Data = enquiryViewModel
            });
        }

        [HttpPost]
        public async Task<ActionResult<EssenceResponse<EnquiryViewModel>>> Post(EnquiryViewModel enquiryViewModel)
        {
            try
            {
                var enquiry = mapper.Map<Enquiry>(enquiryViewModel);

                await enquiryRepository.AddAsync(enquiry);

                var client = _clientFactory.CreateClient("vault");
                enquiry.Source = essenceApiConfig.EnquirySource;

                var enquiryJson = new StringContent(JsonSerializer.Serialize(enquiry));

                using var httpResponse =
                    await client.PostAsync(essenceApiConfig.EnquiryUrl, enquiryJson);

                httpResponse.EnsureSuccessStatusCode();

                var enquiryViewModelResult = mapper.Map<EnquiryViewModel>(enquiry);

                return Ok(new EssenceResponse<EnquiryViewModel>
                {
                    Data = enquiryViewModelResult
                });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
  
}
