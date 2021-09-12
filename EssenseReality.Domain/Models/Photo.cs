﻿using System;

namespace EssenseReality.Domain.Models
{
    public class Photo : WhoFields
    {
        public bool Published { get; set; }
        public int Width { get; set; }
        public string Filename { get; set; }
        public string UserFilename { get; set; }
        public string Type { get; set; }
        public int Height { get; set; }
        public int Filesize { get; set; }
        public string Url { get; set; }
        public int Id { get; set; }
        public DateTime Inserted { get; set; }
        public Thumbnail Thumbnails { get; set; }
        public DateTime Modified { get; set; }
    }


}
