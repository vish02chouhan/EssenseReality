

using System;

namespace EssenceRealty.Web.API
{
    public class EssenceApiConfig
    {
        public string ErFilePath { get; set; }
        public string ErImagePath { get; set; }
        public string Thumb1024 { get; set; }
        public string Thumb180 { get; set; }
        public string ServerUrl { get; set; }
        public string EssenceEmailSendGrid {  get; set; } = Environment.GetEnvironmentVariable("EssenceEmailSendGrid");

    }

}
