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
  public class CommissionSplit {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public decimal? Id { get; set; }

    /// <summary>
    /// Gets or Sets User
    /// </summary>
    [DataMember(Name="user", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "user")]
    public Access User { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public CommissionSplitType Type { get; set; }

    /// <summary>
    /// Gets or Sets ConjunctingAgent
    /// </summary>
    [DataMember(Name="conjunctingAgent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "conjunctingAgent")]
    public ContactMinimal ConjunctingAgent { get; set; }

    /// <summary>
    /// Gets or Sets GrossPercent
    /// </summary>
    [DataMember(Name="grossPercent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "grossPercent")]
    public float? GrossPercent { get; set; }

    /// <summary>
    /// Gets or Sets GrossAmount
    /// </summary>
    [DataMember(Name="grossAmount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "grossAmount")]
    public float? GrossAmount { get; set; }

    /// <summary>
    /// Gets or Sets GrossAmountLessDeductions
    /// </summary>
    [DataMember(Name="grossAmountLessDeductions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "grossAmountLessDeductions")]
    public float? GrossAmountLessDeductions { get; set; }

    /// <summary>
    /// Gets or Sets NetPercent
    /// </summary>
    [DataMember(Name="netPercent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "netPercent")]
    public float? NetPercent { get; set; }

    /// <summary>
    /// Gets or Sets NetAmount
    /// </summary>
    [DataMember(Name="netAmount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "netAmount")]
    public float? NetAmount { get; set; }

    /// <summary>
    /// Gets or Sets Details
    /// </summary>
    [DataMember(Name="details", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "details")]
    public string Details { get; set; }

    /// <summary>
    /// Gets or Sets Branch
    /// </summary>
    [DataMember(Name="branch", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "branch")]
    public AccountBranch Branch { get; set; }

    /// <summary>
    /// Gets or Sets Deductions
    /// </summary>
    [DataMember(Name="deductions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "deductions")]
    public List<CommissionSplitDeduction> Deductions { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CommissionSplit {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  User: ").Append(User).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  ConjunctingAgent: ").Append(ConjunctingAgent).Append("\n");
      sb.Append("  GrossPercent: ").Append(GrossPercent).Append("\n");
      sb.Append("  GrossAmount: ").Append(GrossAmount).Append("\n");
      sb.Append("  GrossAmountLessDeductions: ").Append(GrossAmountLessDeductions).Append("\n");
      sb.Append("  NetPercent: ").Append(NetPercent).Append("\n");
      sb.Append("  NetAmount: ").Append(NetAmount).Append("\n");
      sb.Append("  Details: ").Append(Details).Append("\n");
      sb.Append("  Branch: ").Append(Branch).Append("\n");
      sb.Append("  Deductions: ").Append(Deductions).Append("\n");
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
