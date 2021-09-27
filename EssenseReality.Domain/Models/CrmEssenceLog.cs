﻿using System;
using System.Collections.Generic;

namespace EssenseReality.Domain.Models
{
    public class CrmEssenceLog : WhoFields
    {
        public int Id { get; set; }
        public Guid ProcessingGroupId { get; set; }
        public string JsonObjectBatch {  get; set; }
        public string EndPointUrl {  get; set; }
        public int PageNumber {  get; set; }
        public int TotalItems { get; set; }
        public int JsonObjectBatchItems { get; set; }
        public DateTime RecivedDateTime {  get; set; }
        public DateTime? ProcessedDateTime { get; set; }
        public LogTransactionStatus Status {  get; set; }
        public EssenceObjectTypes EssenceObjectTypes { get; set; }
        public int Retry { get; set; }
        public ICollection<CrmEssenceTransaction> CrmEssenceTransaction { get; set; }


    }

}
