using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class CrmEssenceTransaction:WhoFields
    {
        public int Id { get; set; }
        public string DataId { get; set; }
        public CrmEssenceLog CrmEssenceLog { get; set; }
        public string JsonObject { get; set; }
        public Status Status { get; set; }
        public string Description {  get; set; }
        public int Retry { get; set; }
    }

    public enum Status
    {
        Pending,
        InProgress,
        Processed,
        PartiallyProcessed,
        Failed
    }

}
