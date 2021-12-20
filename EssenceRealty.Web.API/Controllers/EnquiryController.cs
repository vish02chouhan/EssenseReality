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
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

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
        [Authorize]
        public async Task<ActionResult<EssenceResponse<EnquiryViewModel>>> GetAll(int pageNumber, int pageSize)
        {
            var enquiryCount = await enquiryRepository.GetCount();
            var result = await enquiryRepository.GetPagedReponseAsync(pageNumber, pageSize);
            var enquiryViewModel = mapper.Map<IEnumerable<EnquiryViewModel>>(result);

            return Ok(new EssencePaginationResponse<IEnumerable<EnquiryViewModel>>
            {
                Data = enquiryViewModel,
                TotalCount = enquiryCount
            });
        }

        [HttpGet("{id}")]
        [Authorize]
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
            string message = "";
            try
            {
              
                var enquiry = mapper.Map<Enquiry>(enquiryViewModel);
                enquiry.EnquiryDate = DateTime.Now;

                await enquiryRepository.AddAsync(enquiry);

                message += "Data is successfully saved in database.";
                var client = _clientFactory.CreateClient("vault");


                var enquiryToVault = new
                {
                    enquiryDate = enquiry.EnquiryDate,
                    subject = enquiry.Subject,
                    body = enquiry.Body,
                    originalId = enquiry.OriginalId,
                    propertyReference = enquiry.PropertyReference,
                    source = essenceApiConfig.EnquirySource,
                    saleLifeId = enquiry.SaleLifeId,
                    leaseLifeId = enquiry.LeaseLifeId,
                    userId = enquiry.UserId,
                    fullName = enquiry.FullName,
                    firstName = enquiry.FirstName,
                    lastName = enquiry.LastName,
                    email = enquiry.Email,
                    telephone = enquiry.Telephone,
                    mobile = enquiry.Mobile
                };
                var enquiryToVaultContent = new StringContent(JsonConvert.SerializeObject(enquiryToVault), Encoding.UTF8, "application/json");

                using var httpResponse =
                    await client.PostAsync(essenceApiConfig.EnquiryUrl, enquiryToVaultContent);
                httpResponse.EnsureSuccessStatusCode();

                var enquiryViewModelResult = mapper.Map<EnquiryViewModel>(enquiry);

                return Ok(new EssenceResponse<EnquiryViewModel>
                {
                    Data = enquiryViewModelResult,
                    Message = new List<string> {message}
                });
            }
            catch(Exception ex)
            {
                if(message != string.Empty)
                {
                    message += "Error while sending enquiry to vault";
                    return Ok(message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }        
            }
        }

        [HttpPost("{pageNumber}/{pageSize}")]
        [Authorize]
        public async Task<ActionResult<EssencePaginationResponse<EnquiryViewModel>>> Post(int pageNumber, int pageSize, EnquirySearchRequest enquirySearchRequest)
        {
            var result = await enquiryRepository.SearchAsync(enquirySearchRequest, pageNumber, pageSize);

            var enquiryViewModel = mapper.Map<IEnumerable<EnquiryViewModel>>(result.Item1);

            return Ok(new EssencePaginationResponse<IEnumerable<EnquiryViewModel>>
            {
                Data = enquiryViewModel,
                TotalCount = result.Item2
            });

        }
    }
  
}
