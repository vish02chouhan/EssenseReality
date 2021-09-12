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
  public class Tenancy {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

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
    /// Gets or Sets Rent
    /// </summary>
    [DataMember(Name="rent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rent")]
    public float? Rent { get; set; }

    /// <summary>
    /// Gets or Sets RentFrequency
    /// </summary>
    [DataMember(Name="rentFrequency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rentFrequency")]
    public RentFrequency RentFrequency { get; set; }

    /// <summary>
    /// Gets or Sets Archived
    /// </summary>
    [DataMember(Name="archived", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "archived")]
    public bool? Archived { get; set; }

    /// <summary>
    /// Gets or Sets LetAgreed
    /// </summary>
    [DataMember(Name="letAgreed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "letAgreed")]
    public bool? LetAgreed { get; set; }

    /// <summary>
    /// Gets or Sets Start
    /// </summary>
    [DataMember(Name="start", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "start")]
    public DateTime? Start { get; set; }

    /// <summary>
    /// Gets or Sets End
    /// </summary>
    [DataMember(Name="end", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "end")]
    public DateTime? End { get; set; }

    /// <summary>
    /// Gets or Sets RentPaidUntil
    /// </summary>
    [DataMember(Name="rentPaidUntil", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rentPaidUntil")]
    public DateTime? RentPaidUntil { get; set; }

    /// <summary>
    /// Gets or Sets ArrearsAmount
    /// </summary>
    [DataMember(Name="arrearsAmount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "arrearsAmount")]
    public float? ArrearsAmount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Tenancy {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Modified: ").Append(Modified).Append("\n");
      sb.Append("  Rent: ").Append(Rent).Append("\n");
      sb.Append("  RentFrequency: ").Append(RentFrequency).Append("\n");
      sb.Append("  Archived: ").Append(Archived).Append("\n");
      sb.Append("  LetAgreed: ").Append(LetAgreed).Append("\n");
      sb.Append("  Start: ").Append(Start).Append("\n");
      sb.Append("  End: ").Append(End).Append("\n");
      sb.Append("  RentPaidUntil: ").Append(RentPaidUntil).Append("\n");
      sb.Append("  ArrearsAmount: ").Append(ArrearsAmount).Append("\n");
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
