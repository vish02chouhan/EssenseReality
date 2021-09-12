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
  public class CommercialDeal {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public decimal? Id { get; set; }

    /// <summary>
    /// Gets or Sets Owners
    /// </summary>
    [DataMember(Name="owners", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "owners")]
    public List<ContactMinimal> Owners { get; set; }

    /// <summary>
    /// Gets or Sets Tenants
    /// </summary>
    [DataMember(Name="tenants", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenants")]
    public List<ContactMinimal> Tenants { get; set; }

    /// <summary>
    /// Gets or Sets Unconditional
    /// </summary>
    [DataMember(Name="unconditional", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unconditional")]
    public DateTime? Unconditional { get; set; }

    /// <summary>
    /// Gets or Sets Settlement
    /// </summary>
    [DataMember(Name="settlement", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "settlement")]
    public DateTime? Settlement { get; set; }

    /// <summary>
    /// Gets or Sets GrossCommissionExcGST
    /// </summary>
    [DataMember(Name="grossCommissionExcGST", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "grossCommissionExcGST")]
    public float? GrossCommissionExcGST { get; set; }

    /// <summary>
    /// Gets or Sets OutgoingsPerAnnum
    /// </summary>
    [DataMember(Name="outgoingsPerAnnum", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "outgoingsPerAnnum")]
    public float? OutgoingsPerAnnum { get; set; }

    /// <summary>
    /// Gets or Sets OutgoingsText
    /// </summary>
    [DataMember(Name="outgoingsText", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "outgoingsText")]
    public string OutgoingsText { get; set; }

    /// <summary>
    /// Gets or Sets ParkingBays
    /// </summary>
    [DataMember(Name="parkingBays", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parkingBays")]
    public decimal? ParkingBays { get; set; }

    /// <summary>
    /// Gets or Sets ParkingInfo
    /// </summary>
    [DataMember(Name="parkingInfo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parkingInfo")]
    public string ParkingInfo { get; set; }

    /// <summary>
    /// Gets or Sets ExternalAgency
    /// </summary>
    [DataMember(Name="externalAgency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "externalAgency")]
    public ContactMinimal ExternalAgency { get; set; }

    /// <summary>
    /// Gets or Sets OurDeal
    /// </summary>
    [DataMember(Name="ourDeal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ourDeal")]
    public bool? OurDeal { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CommercialDeal {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Owners: ").Append(Owners).Append("\n");
      sb.Append("  Tenants: ").Append(Tenants).Append("\n");
      sb.Append("  Unconditional: ").Append(Unconditional).Append("\n");
      sb.Append("  Settlement: ").Append(Settlement).Append("\n");
      sb.Append("  GrossCommissionExcGST: ").Append(GrossCommissionExcGST).Append("\n");
      sb.Append("  OutgoingsPerAnnum: ").Append(OutgoingsPerAnnum).Append("\n");
      sb.Append("  OutgoingsText: ").Append(OutgoingsText).Append("\n");
      sb.Append("  ParkingBays: ").Append(ParkingBays).Append("\n");
      sb.Append("  ParkingInfo: ").Append(ParkingInfo).Append("\n");
      sb.Append("  ExternalAgency: ").Append(ExternalAgency).Append("\n");
      sb.Append("  OurDeal: ").Append(OurDeal).Append("\n");
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
