using System.Collections.Generic;

namespace EssenceRealty.Domain.ViewModels
{
    public class FloorPlanViewModel
    {
        public int Id { get; set; }
        public List<PhotoViewModel> Photos { get; set; }
        public string Description { get; set; }
    }


}
