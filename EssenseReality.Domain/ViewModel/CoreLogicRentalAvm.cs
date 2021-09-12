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
  public class CoreLogicRentalAvm {
    /// <summary>
    /// Gets or Sets EstimatedPricePerWeekHigh
    /// </summary>
    [DataMember(Name="estimatedPricePerWeekHigh", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "estimatedPricePerWeekHigh")]
    public float? EstimatedPricePerWeekHigh { get; set; }

    /// <summary>
    /// Gets or Sets EstimatedPricePerWeekLow
    /// </summary>
    [DataMember(Name="estimatedPricePerWeekLow", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "estimatedPricePerWeekLow")]
    public float? EstimatedPricePerWeekLow { get; set; }

    /// <summary>
    /// Gets or Sets EstimatedValuePerWeek
    /// </summary>
    [DataMember(Name="estimatedValuePerWeek", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "estimatedValuePerWeek")]
    public float? EstimatedValuePerWeek { get; set; }

    /// <summary>
    /// Gets or Sets ForecastStandardDeviation
    /// </summary>
    [DataMember(Name="forecastStandardDeviation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "forecastStandardDeviation")]
    public float? ForecastStandardDeviation { get; set; }

    /// <summary>
    /// Gets or Sets YieldForecastStandardDeviation
    /// </summary>
    [DataMember(Name="yieldForecastStandardDeviation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "yieldForecastStandardDeviation")]
    public float? YieldForecastStandardDeviation { get; set; }

    /// <summary>
    /// Gets or Sets Yield
    /// </summary>
    [DataMember(Name="yield", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "yield")]
    public float? Yield { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CoreLogicRentalAvm {\n");
      sb.Append("  EstimatedPricePerWeekHigh: ").Append(EstimatedPricePerWeekHigh).Append("\n");
      sb.Append("  EstimatedPricePerWeekLow: ").Append(EstimatedPricePerWeekLow).Append("\n");
      sb.Append("  EstimatedValuePerWeek: ").Append(EstimatedValuePerWeek).Append("\n");
      sb.Append("  ForecastStandardDeviation: ").Append(ForecastStandardDeviation).Append("\n");
      sb.Append("  YieldForecastStandardDeviation: ").Append(YieldForecastStandardDeviation).Append("\n");
      sb.Append("  Yield: ").Append(Yield).Append("\n");
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
