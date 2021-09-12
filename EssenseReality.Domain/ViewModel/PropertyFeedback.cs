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
  public class PropertyFeedback {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets Property
    /// </summary>
    [DataMember(Name="property", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "property")]
    public PropertyFeedbackProperty Property { get; set; }

    /// <summary>
    /// Gets or Sets FeedbackDate
    /// </summary>
    [DataMember(Name="feedbackDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "feedbackDate")]
    public DateTime? FeedbackDate { get; set; }

    /// <summary>
    /// Gets or Sets PriceOpinion
    /// </summary>
    [DataMember(Name="priceOpinion", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "priceOpinion")]
    public float? PriceOpinion { get; set; }

    /// <summary>
    /// Gets or Sets SaleLifeId
    /// </summary>
    [DataMember(Name="saleLifeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "saleLifeId")]
    public decimal? SaleLifeId { get; set; }

    /// <summary>
    /// Gets or Sets LeaseLifeId
    /// </summary>
    [DataMember(Name="leaseLifeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "leaseLifeId")]
    public decimal? LeaseLifeId { get; set; }

    /// <summary>
    /// Gets or Sets ContractRequested
    /// </summary>
    [DataMember(Name="contractRequested", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contractRequested")]
    public bool? ContractRequested { get; set; }

    /// <summary>
    /// Gets or Sets ContractSent
    /// </summary>
    [DataMember(Name="contractSent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contractSent")]
    public DateTime? ContractSent { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PropertyFeedback {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Property: ").Append(Property).Append("\n");
      sb.Append("  FeedbackDate: ").Append(FeedbackDate).Append("\n");
      sb.Append("  PriceOpinion: ").Append(PriceOpinion).Append("\n");
      sb.Append("  SaleLifeId: ").Append(SaleLifeId).Append("\n");
      sb.Append("  LeaseLifeId: ").Append(LeaseLifeId).Append("\n");
      sb.Append("  ContractRequested: ").Append(ContractRequested).Append("\n");
      sb.Append("  ContractSent: ").Append(ContractSent).Append("\n");
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
