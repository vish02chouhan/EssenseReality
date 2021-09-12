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
  public class LeaseHistory {
    /// <summary>
    /// Gets or Sets LifeId
    /// </summary>
    [DataMember(Name="lifeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lifeId")]
    public decimal? LifeId { get; set; }

    /// <summary>
    /// Gets or Sets Appraisal
    /// </summary>
    [DataMember(Name="appraisal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "appraisal")]
    public DateTime? Appraisal { get; set; }

    /// <summary>
    /// Gets or Sets AppraisalPriceLower
    /// </summary>
    [DataMember(Name="appraisalPriceLower", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "appraisalPriceLower")]
    public float? AppraisalPriceLower { get; set; }

    /// <summary>
    /// Gets or Sets AppraisalPriceUpper
    /// </summary>
    [DataMember(Name="appraisalPriceUpper", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "appraisalPriceUpper")]
    public float? AppraisalPriceUpper { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or Sets PortalStatus
    /// </summary>
    [DataMember(Name="portalStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "portalStatus")]
    public string PortalStatus { get; set; }

    /// <summary>
    /// Gets or Sets Inserted
    /// </summary>
    [DataMember(Name="inserted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "inserted")]
    public DateTime? Inserted { get; set; }

    /// <summary>
    /// Gets or Sets Modified
    /// </summary>
    [DataMember(Name="modified", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modified")]
    public DateTime? Modified { get; set; }

    /// <summary>
    /// Gets or Sets ContactStaff
    /// </summary>
    [DataMember(Name="contactStaff", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contactStaff")]
    public List<Access> ContactStaff { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LeaseHistory {\n");
      sb.Append("  LifeId: ").Append(LifeId).Append("\n");
      sb.Append("  Appraisal: ").Append(Appraisal).Append("\n");
      sb.Append("  AppraisalPriceLower: ").Append(AppraisalPriceLower).Append("\n");
      sb.Append("  AppraisalPriceUpper: ").Append(AppraisalPriceUpper).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  PortalStatus: ").Append(PortalStatus).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Modified: ").Append(Modified).Append("\n");
      sb.Append("  ContactStaff: ").Append(ContactStaff).Append("\n");
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
