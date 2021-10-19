using System.Collections.Generic;

namespace EssenceRealty.Web.API.Model
{
    public class EssenceResponse<T>
    {
        public T Data { get; set; }

        public List<string> Message { get; set; }
    }

    public class ERConfiguration
    {
        public string ERImagePath { get; set; }
    }
}
