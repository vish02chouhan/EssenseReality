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
        public async Task<IEnumerable<ContactStaffViewModel>> GetAll()
        {
            var result = await contactStaffRepository.ListAllAsync();

            var contactStaffViewModel = mapper.Map<IEnumerable<ContactStaffViewModel>>(result);

            return contactStaffViewModel;
        }

        [HttpGet("{id}")]
        public async Task<ContactStaffViewModel> Get(int id)
        {
            var result = await contactStaffRepository.GetByIdAsync(id);

            var contactStaffViewModel = mapper.Map<ContactStaffViewModel>(result);

            return contactStaffViewModel;
        }

        [HttpPut]
        public async Task<ContactStaffViewModel> Put(ContactStaffViewModel contactStaffViewModel)
        {

            var contactStaff = mapper.Map<ContactStaff>(contactStaffViewModel);

            await contactStaffRepository.UpdateAsync(contactStaff);

            return mapper.Map<ContactStaffViewModel>(contactStaff);
        }
    }
  
}
