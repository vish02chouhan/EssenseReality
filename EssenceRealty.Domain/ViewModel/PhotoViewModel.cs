using System;
using System.Collections.Generic;

namespace EssenceRealty.Domain.ViewModels
{
    public class PhotoViewModel
    {

        public int Id { get; set; }
        public bool Published { get; set; }
        public int? Width { get; set; }
        public string Filename { get; set; }
        public string UserFilename { get; set; }
        public string Type { get; set; }
        public int? Height { get; set; }
        public int? Filesize { get; set; }
        public string Url { get; set; }
        public string Thumb1024 { get; set; }
        public string Thumb180 { get; set; }
        public int PropertyId { get; set; }
    }


}
