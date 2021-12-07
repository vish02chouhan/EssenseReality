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
using EssenceRealty.Data.Identity.Models;
using EssenceRealty.Data.Identity.Contract;
using EssenceRealty.Domain.Helper;

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ContactStaffController : ControllerBase
    {

        private readonly ILogger<ContactStaffController> _logger;
        private readonly IContactStaffRepository contactStaffRepository;
        private readonly IMapper mapper;
        private readonly IAuthenticationService authenticationService;

        public ContactStaffController(ILogger<ContactStaffController> logger, IContactStaffRepository contactStaffRepository,
            IMapper mapper,
            IAuthenticationService authenticationService)
        {
            _logger = logger;
            this.contactStaffRepository = contactStaffRepository;
            this.mapper = mapper;
            this.authenticationService = authenticationService;
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

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<EssenceResponse<ContactStaffViewModel>>> Post(ContactStaffViewModel contactStaffViewModel)
        {
            if(contactStaffViewModel == null || contactStaffViewModel.Id > 0)
            {
                return BadRequest();
            }

            var contactStaff = mapper.Map<ContactStaff>(contactStaffViewModel);

            await contactStaffRepository.AddAsync(contactStaff);

            var request = new RegistrationRequest
            {
                FirstName = contactStaffViewModel.FirstName,
                LastName = contactStaffViewModel.LastName,
                Email = contactStaffViewModel.Email,
                UserName = contactStaffViewModel.Email,
                Password = $"{contactStaffViewModel.FirstName.FirstCharToUpper()}@123"
            };
            try
            {
                await authenticationService.RegisterAsync(request);
            }
            catch
            {
            }

            var contactStaffViewModelResult = mapper.Map<ContactStaffViewModel>(contactStaff);

            return Ok(new EssenceResponse<ContactStaffViewModel>
            {
                Data = contactStaffViewModelResult
            });
        }
    }
  
}
