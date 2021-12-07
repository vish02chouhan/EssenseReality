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
using System.Text;

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class VCardController : ControllerBase
    {

        private readonly ILogger<ContactStaffController> _logger;
        private readonly IContactStaffRepository contactStaffRepository;
        private readonly IMapper mapper;

        public VCardController(ILogger<ContactStaffController> logger, IContactStaffRepository contactStaffRepository,
            IMapper mapper)
        {
            _logger = logger;
            this.contactStaffRepository = contactStaffRepository;
            this.mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task Get(int id)
        {
            var result = await contactStaffRepository.GetByIdAsync(id);
            var contactStaffViewModel = mapper.Map<ContactStaffViewModel>(result);
            var fileName = contactStaffViewModel.GetFullName() + ".vcf";
            var disposition = "attachment; filename=" + fileName;
            var response = HttpContext.Response;

            response.ContentType = "text/vcard";
            response.Headers.Add("Content-disposition", disposition);
            var bytes = Encoding.UTF8.GetBytes(contactStaffViewModel.ToString());
            await response.Body.WriteAsync(bytes, 0, bytes.Length);

            //return Ok(new EssenceResponse<ContactStaffViewModel>
            //{
            //    Data = contactStaffViewModel
            //});
        }
    }
  
}
