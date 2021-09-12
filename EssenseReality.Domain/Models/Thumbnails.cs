using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenseReality.Domain.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Thumbnail : WhoFields
    {
        public int Id { get; set; }
        public string Thumb1024 { get; set; }
        public string Thumb180 { get; set; }
    }
}
