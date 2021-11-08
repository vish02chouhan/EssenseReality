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
using Microsoft.AspNetCore.Authorization;

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ContactStaffController : ControllerBase
    {

        private readonly ILogger<ContactStaffController> _logger;
        private readonly IContactStaffRepository contactStaffRepository;
        private readonly IMapper mapper;

        public ContactStaffController(ILogger<ContactStaffController> logger, IContactStaffRepository contactStaffRepository,
            IMapper mapper)
        {
            _logger = logger;
            this.contactStaffRepository = contactStaffRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<ContactStaffViewModel>>> GetAll()
        {
            var result = await contactStaffRepository.ListAllAsync();

            var contactStaffViewModel = mapper.Map<IEnumerable<ContactStaffViewModel>>(result);

            return Ok(new EssenceResponse<IEnumerable<ContactStaffViewModel>>
            {
                Data =  contactStaffViewModel
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EssenceResponse<ContactStaffViewModel>>> Get(int id)
        {
            var result = await contactStaffRepository.GetByIdAsync(id);

            var contactStaffViewModel = mapper.Map<ContactStaffViewModel>(result);

            return Ok(new EssenceResponse<ContactStaffViewModel>
            {
                Data = contactStaffViewModel
            });
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<EssenceResponse<ContactStaffViewModel>>> Put(ContactStaffViewModel contactStaffViewModel)
        {

            var contactStaff = mapper.Map<ContactStaff>(contactStaffViewModel);

            await contactStaffRepository.UpdateAsync(contactStaff);

            var contactStaffViewModelResult = mapper.Map<ContactStaffViewModel>(contactStaff);

            return Ok(new EssenceResponse<ContactStaffViewModel>
            {
                Data = contactStaffViewModelResult
            });
        }
    }
  
}
