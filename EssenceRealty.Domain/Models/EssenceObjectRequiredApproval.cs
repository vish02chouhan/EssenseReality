namespace EssenceRealty.Domain.Models
{
    public class EssenceObjectRequiredApproval : WhoFields
    {
        public int Id { get; set; }
        public int CrmPropertyId { get; set; } //112
        public Property Property { get; set; }
        public string JsonObject { get; set; }
        public EssenceObjectTypes EssenceObjectTypes { get; set; }
        //public CrmEssenceTransaction CrmEssenceTransaction { get; set; }
        public EssenceObjectRequiredApprovalStatus EssenceObjectRequiredApprovalStatus { get; set; }
        //pending => //Approved => record override in property table with modified date and adminupdate to false => status update to approved & this will not pick again
        //pending => //Reject => update CRM modified date in property table and adminupdate remain to true=> status update to reject & this will not pick again


        //pending => day1 => admin => no action
        //pending => day2 => if exists in EssenceObjectRequiredApproval then update else insert new record

    }
}