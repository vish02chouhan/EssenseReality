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
  public class AddUpdatePropertyFeedback {
    /// <summary>
    /// Gets or Sets PriceOpinion
    /// </summary>
    [DataMember(Name="priceOpinion", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "priceOpinion")]
    public float? PriceOpinion { get; set; }

    /// <summary>
    /// Gets or Sets FeedbackDate
    /// </summary>
    [DataMember(Name="feedbackDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "feedbackDate")]
    public DateTime? FeedbackDate { get; set; }

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
      sb.Append("class AddUpdatePropertyFeedback {\n");
      sb.Append("  PriceOpinion: ").Append(PriceOpinion).Append("\n");
      sb.Append("  FeedbackDate: ").Append(FeedbackDate).Append("\n");
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
