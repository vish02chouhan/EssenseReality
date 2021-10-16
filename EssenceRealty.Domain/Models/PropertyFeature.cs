namespace EssenceRealty.Domain.Models
{
    public class PropertyFeature : WhoFields
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets DataType
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        public string Data { get; set; }

    }
}
