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
  public class CoreLogicAvm {
    /// <summary>
    /// Gets or Sets EstimatedPriceHigh
    /// </summary>
    [DataMember(Name="estimatedPriceHigh", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "estimatedPriceHigh")]
    public float? EstimatedPriceHigh { get; set; }

    /// <summary>
    /// Gets or Sets EstimatedPriceLow
    /// </summary>
    [DataMember(Name="estimatedPriceLow", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "estimatedPriceLow")]
    public float? EstimatedPriceLow { get; set; }

    /// <summary>
    /// Gets or Sets EstimatedValue
    /// </summary>
    [DataMember(Name="estimatedValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "estimatedValue")]
    public float? EstimatedValue { get; set; }

    /// <summary>
    /// Gets or Sets Confidence
    /// </summary>
    [DataMember(Name="confidence", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "confidence")]
    public string Confidence { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CoreLogicAvm {\n");
      sb.Append("  EstimatedPriceHigh: ").Append(EstimatedPriceHigh).Append("\n");
      sb.Append("  EstimatedPriceLow: ").Append(EstimatedPriceLow).Append("\n");
      sb.Append("  EstimatedValue: ").Append(EstimatedValue).Append("\n");
      sb.Append("  Confidence: ").Append(Confidence).Append("\n");
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
