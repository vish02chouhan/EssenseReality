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

    public class EnquiryController : ControllerBase
    {

        private readonly ILogger<EnquiryController> _logger;
        private readonly IEnquiryRepository enquiryRepository;
        private readonly IMapper mapper;

        public EnquiryController(ILogger<EnquiryController> logger, IEnquiryRepository enquiryRepository,
            IMapper mapper)
        {
            _logger = logger;
            this.enquiryRepository = enquiryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<EnquiryViewModel>>> GetAll()
        {
            var result = await enquiryRepository.ListAllAsync();

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

            var enquiry = mapper.Map<Enquiry>(enquiryViewModel);

            await enquiryRepository.AddAsync(enquiry);

            var enquiryViewModelResult = mapper.Map<EnquiryViewModel>(enquiry);

            return Ok(new EssenceResponse<EnquiryViewModel>
            {
                Data = enquiryViewModelResult
            });
        }
    }
  
}
