using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceRealty.Domain.Models
{
    public class PropertyFeatureGrouping
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or Sets GroupName
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or Sets GroupDisplayName
        public string GroupDisplayName { get; set; }

        /// <summary>
        /// Gets or Sets Features
        /// </summary>
        public List<PropertyFeature> Features { get; set; }

    }
}
