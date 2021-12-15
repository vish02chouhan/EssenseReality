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
using Microsoft.AspNetCore.Http;
using EssenceRealty.Web.API.Helper;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;

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
        private readonly IWebHostEnvironment environment;
        private readonly IPropertyContactStaffRepository propertyContactStaffRepository;
        private readonly EssenceApiConfig essenceApiConfig;

        public ContactStaffController(ILogger<ContactStaffController> logger, IContactStaffRepository contactStaffRepository,IMapper mapper, IAuthenticationService authenticationService, IOptions<EssenceApiConfig> config, IWebHostEnvironment environment, IPropertyContactStaffRepository propertyContactStaffRepository)
        {
            _logger = logger;
            this.contactStaffRepository = contactStaffRepository;
            this.mapper = mapper;
            this.authenticationService = authenticationService;
            this.environment = environment;
            this.propertyContactStaffRepository = propertyContactStaffRepository;
            essenceApiConfig = config.Value;
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

            if (result == null)
            {
                return NotFound();
            }

            var contactStaffViewModel = mapper.Map<ContactStaffViewModel>(result);

            return Ok(new EssenceResponse<ContactStaffViewModel>
            {
                Data = contactStaffViewModel
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await contactStaffRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            var contactsProperty = await propertyContactStaffRepository.GetManyAsync(x => x.ContactStaffId == id);
            if (contactsProperty != null || contactsProperty.Count > 0)
            {
                return BadRequest("Cannot delete. Properties exists for contact.");
            }

            await contactStaffRepository.DeleteAsync(result);

            return Ok();

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
        [Authorize]
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


        [HttpPost("photo")]
        [Authorize]
        public async Task<ActionResult<EssenceResponse<PhotoViewModel>>> PostContactStaff(IFormFile formFile, int contactStaffId)
        {
            string url360, url;

            var result = await contactStaffRepository.GetByIdAsync(contactStaffId);

            if(result == null)
            {
                return NotFound();
            }

            if (formFile.Length > 0)
            {

                (url360, url) = await ImageProcessor.ProcessContactStaffImage(formFile, contactStaffId, essenceApiConfig, environment);
                result.OriginalPhotoURL = url;
                result.Thumb_360PhotoURL = url360;

               await contactStaffRepository.SaveChanges();

            }

            var contactStaffViewModel = mapper.Map<ContactStaffViewModel>(result);

            return Ok(new EssenceResponse<ContactStaffViewModel>
            {
                Data = contactStaffViewModel
            });
        }
   
    
    }
  
}
