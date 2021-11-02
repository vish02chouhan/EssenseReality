﻿using System;

namespace EssenceRealty.Domain.ViewModels
{
    public class FloorPlanFilesViewModel
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
    }
}
