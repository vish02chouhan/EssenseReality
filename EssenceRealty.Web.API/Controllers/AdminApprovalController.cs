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
using System.Text.Json;

namespace EssenceRealty.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AdminApprovalController : ControllerBase
    {

        private readonly ILogger<AdminApprovalController> _logger;
        private readonly IPropertyRepository propertyRepository;
        private readonly IEssenceObjectRequiredApprovalRepository essenceObjectRequiredApprovalRepository;
        private readonly IMapper mapper;

        public AdminApprovalController(ILogger<AdminApprovalController> logger, IPropertyRepository propertyRepository,
            IEssenceObjectRequiredApprovalRepository essenceObjectRequiredApprovalRepository, IMapper mapper)
        {
            _logger = logger;
            this.propertyRepository = propertyRepository;
            this.essenceObjectRequiredApprovalRepository = essenceObjectRequiredApprovalRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EssenceResponse<EssenceObjectRequiredApprovalViewModel>>> GetAll()
        {
            var result = await essenceObjectRequiredApprovalRepository.ListAllAsync();

            var essenceObjectRequiredApprovalViewModel = mapper.Map<IEnumerable<EssenceObjectRequiredApprovalViewModel>>(result);

            return Ok(new EssenceResponse<IEnumerable<EssenceObjectRequiredApprovalViewModel>>
            {
                Data = essenceObjectRequiredApprovalViewModel
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EssenceResponse<EssenceObjectRequiredApprovalViewModel>>> Get(int id)
        {
            var result = await essenceObjectRequiredApprovalRepository.GetByIdAsync(id);

            var essenceObjectRequiredApprovalViewModel = mapper.Map<EssenceObjectRequiredApprovalViewModel>(result);

            return Ok(new EssenceResponse<EssenceObjectRequiredApprovalViewModel>
            {
                Data = essenceObjectRequiredApprovalViewModel
            });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, bool isApproved)
        {
            EssenceObjectRequiredApproval objEssenceObjectRequiredApproval = await essenceObjectRequiredApprovalRepository.GetByIdAsync(id);
            objEssenceObjectRequiredApproval.ModifiedDate = System.DateTime.Now;
            Property objProperty = JsonSerializer.Deserialize<Property>(objEssenceObjectRequiredApproval.JsonObject);

            Property objDBProperty = await propertyRepository.GetPropertyByCRMID(objProperty.CrmPropertyId);

            Property objUpdatedProperty = new();
            if (isApproved)
            {
                objUpdatedProperty = objProperty;
                objUpdatedProperty.Id = objDBProperty.Id;
                objUpdatedProperty.IsAdminUpdated = false;
                objUpdatedProperty.ModifiedDate = System.DateTime.Now;
                objEssenceObjectRequiredApproval.EssenceObjectRequiredApprovalStatus = EssenceObjectRequiredApprovalStatus.Approved;
            }
            else
            {
                objUpdatedProperty = objDBProperty;
                objUpdatedProperty.Inserted = objProperty.Inserted;
                objUpdatedProperty.Modified = objProperty.Modified;
                objUpdatedProperty.IsAdminUpdated = true;
                objUpdatedProperty.ModifiedDate = System.DateTime.Now;
                objEssenceObjectRequiredApproval.EssenceObjectRequiredApprovalStatus = EssenceObjectRequiredApprovalStatus.Rejected;
            }
            await propertyRepository.UpdateProperty(objUpdatedProperty);
            await essenceObjectRequiredApprovalRepository.UpdateAsync(objEssenceObjectRequiredApproval);

            return Ok();
        }
    }
  
}
