using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class AddUpdateContactRequirement {
    /// <summary>
    /// Gets or Sets Active
    /// </summary>
    [DataMember(Name="active", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "active")]
    public bool? Active { get; set; }

    /// <summary>
    /// Gets or Sets PropertyClass
    /// </summary>
    [DataMember(Name="propertyClass", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "propertyClass")]
    public ID PropertyClass { get; set; }

    /// <summary>
    /// Gets or Sets MinimumPrice
    /// </summary>
    [DataMember(Name="minimumPrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minimumPrice")]
    public float? MinimumPrice { get; set; }

    /// <summary>
    /// Gets or Sets MaximumPrice
    /// </summary>
    [DataMember(Name="maximumPrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maximumPrice")]
    public float? MaximumPrice { get; set; }

    /// <summary>
    /// Gets or Sets MinimumBed
    /// </summary>
    [DataMember(Name="minimumBed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minimumBed")]
    public long? MinimumBed { get; set; }

    /// <summary>
    /// Gets or Sets MinimumBath
    /// </summary>
    [DataMember(Name="minimumBath", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minimumBath")]
    public long? MinimumBath { get; set; }

    /// <summary>
    /// Gets or Sets MinimumCar
    /// </summary>
    [DataMember(Name="minimumCar", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minimumCar")]
    public long? MinimumCar { get; set; }

    /// <summary>
    /// Gets or Sets MinimumPricePerSQM
    /// </summary>
    [DataMember(Name="minimumPricePerSQM", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minimumPricePerSQM")]
    public float? MinimumPricePerSQM { get; set; }

    /// <summary>
    /// Gets or Sets MaximumPricePerSQM
    /// </summary>
    [DataMember(Name="maximumPricePerSQM", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maximumPricePerSQM")]
    public float? MaximumPricePerSQM { get; set; }

    /// <summary>
    /// Gets or Sets LandArea
    /// </summary>
    [DataMember(Name="landArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "landArea")]
    public AreaRange LandArea { get; set; }

    /// <summary>
    /// Gets or Sets BuildingArea
    /// </summary>
    [DataMember(Name="buildingArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "buildingArea")]
    public AreaRange BuildingArea { get; set; }

    /// <summary>
    /// Gets or Sets PropertyTypes
    /// </summary>
    [DataMember(Name="propertyTypes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "propertyTypes")]
    public List<ID> PropertyTypes { get; set; }

    /// <summary>
    /// Gets or Sets PropertyTags
    /// </summary>
    [DataMember(Name="propertyTags", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "propertyTags")]
    public List<string> PropertyTags { get; set; }

    /// <summary>
    /// Gets or Sets Suburbs
    /// </summary>
    [DataMember(Name="suburbs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "suburbs")]
    public List<Suburb> Suburbs { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or Sets TenantedInvestment
    /// </summary>
    [DataMember(Name="tenantedInvestment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenantedInvestment")]
    public bool? TenantedInvestment { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddUpdateContactRequirement {\n");
      sb.Append("  Active: ").Append(Active).Append("\n");
      sb.Append("  PropertyClass: ").Append(PropertyClass).Append("\n");
      sb.Append("  MinimumPrice: ").Append(MinimumPrice).Append("\n");
      sb.Append("  MaximumPrice: ").Append(MaximumPrice).Append("\n");
      sb.Append("  MinimumBed: ").Append(MinimumBed).Append("\n");
      sb.Append("  MinimumBath: ").Append(MinimumBath).Append("\n");
      sb.Append("  MinimumCar: ").Append(MinimumCar).Append("\n");
      sb.Append("  MinimumPricePerSQM: ").Append(MinimumPricePerSQM).Append("\n");
      sb.Append("  MaximumPricePerSQM: ").Append(MaximumPricePerSQM).Append("\n");
      sb.Append("  LandArea: ").Append(LandArea).Append("\n");
      sb.Append("  BuildingArea: ").Append(BuildingArea).Append("\n");
      sb.Append("  PropertyTypes: ").Append(PropertyTypes).Append("\n");
      sb.Append("  PropertyTags: ").Append(PropertyTags).Append("\n");
      sb.Append("  Suburbs: ").Append(Suburbs).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  TenantedInvestment: ").Append(TenantedInvestment).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
