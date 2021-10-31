using System;
using System.Collections.Generic;

namespace EssenceRealty.Domain.Models
{
    public class FloorPlan
    {
        public int Id { get; set; }
        public List<FloorPlanFiles> Photos { get; set; }
        public string Description { get; set; }
    }

    public class FloorPlanFiles : WhoFields
    {
        public int Id { get; set; }
        public int? Width { get; set; }
        public string Filename { get; set; }
        public string UserFilename { get; set; }
        public string Type { get; set; }
        public long? Filesize { get; set; }
        public string Url { get; set; }
        public DateTime? Inserted { get; set; }
        public DateTime? Modified { get; set; }
        public int? PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
