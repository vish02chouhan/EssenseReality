namespace EssenseReality.Domain.Models
{
    public class EssenceObjectRequiredApproval : WhoFields
    {
        public int Id { get; set; }
        public string DataId { get; set; }
        public string JsonObject { get; set; }
        public EssenceObjectTypes EssenceObjectTypes { get; set; }
        public EssenceObjectRequiredApprovalStatus EssenceObjectRequiredApprovalStatus { get; set; }
        public CrmEssenceTransaction CrmEssenceTransaction { get; set; }
    }
}