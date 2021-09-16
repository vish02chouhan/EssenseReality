using System;

namespace EssenseReality.Domain.Models
{
    public class CrmEssenceLog : WhoFields
    {
        public int Id { get; set; }
        public string JsonObjectBatch {  get; set; }
        public string EndPointUrl {  get; set; }
        public int PageNumber {  get; set; }
        public DateTime RecivedDateTime {  get; set; }
        public DateTime ProcessedDateTime { get; set; }
        public Status Status {  get; set; }
        public int Retry { get; set; }
    }

}
