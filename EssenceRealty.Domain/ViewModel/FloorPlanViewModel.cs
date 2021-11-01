using System.Collections.Generic;

namespace EssenceRealty.Domain.ViewModels
{
    public class FloorPlanViewModel
    {
        public int Id { get; set; }
        public IEnumerable<FloorPlanFilesViewModel> FloorPlanFiles { get; set; }
        public string Description { get; set; }
        public int PropertyId { get; set; }
    }

}
