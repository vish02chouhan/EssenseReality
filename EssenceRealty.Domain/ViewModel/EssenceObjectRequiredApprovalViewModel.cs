using EssenceRealty.Domain.Enums;
using EssenceRealty.Domain.Models;

namespace EssenceRealty.Domain.ViewModels
{
    public class EssenceObjectRequiredApprovalViewModel
    {
        public int Id { get; set; }
        public int? CrmPropertyId { get; set; } 
        public string JsonObject { get; set; }
        public EssenceObjectTypes EssenceObjectTypes { get; set; }
        public EssenceObjectRequiredApprovalStatus EssenceObjectRequiredApprovalStatus { get; set; }
    }
}