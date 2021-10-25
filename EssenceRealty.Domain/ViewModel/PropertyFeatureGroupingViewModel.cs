using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssenceRealty.Domain.ViewModels;

namespace EssenceRealty.Domain.ViewModels
{
    public class PropertyFeatureGroupingViewModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupDisplayName { get; set; }
        public ICollection<PropertyFeatureViewModel> PropertyFeature { get; set; }

    }
}
