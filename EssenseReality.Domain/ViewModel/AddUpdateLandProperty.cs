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
  public class AddUpdateLandProperty : AddUpdateProperty {
    /// <summary>
    /// Gets or Sets Rates
    /// </summary>
    [DataMember(Name="rates", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rates")]
    public SalePropertyRates Rates { get; set; }

    /// <summary>
    /// Gets or Sets ExternalLinks
    /// </summary>
    [DataMember(Name="externalLinks", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "externalLinks")]
    public List<ExternalLink> ExternalLinks { get; set; }

    /// <summary>
    /// Gets or Sets PriceOnApplication
    /// </summary>
    [DataMember(Name="priceOnApplication", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "priceOnApplication")]
    public bool? PriceOnApplication { get; set; }

    /// <summary>
    /// Gets or Sets AuthorityStart
    /// </summary>
    [DataMember(Name="authorityStart", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authorityStart")]
    public DateTime? AuthorityStart { get; set; }

    /// <summary>
    /// Gets or Sets AuthorityEnd
    /// </summary>
    [DataMember(Name="authorityEnd", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authorityEnd")]
    public DateTime? AuthorityEnd { get; set; }

    /// <summary>
    /// Gets or Sets SellingFeePercent
    /// </summary>
    [DataMember(Name="sellingFeePercent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sellingFeePercent")]
    public float? SellingFeePercent { get; set; }

    /// <summary>
    /// Gets or Sets SellingFeeFixed
    /// </summary>
    [DataMember(Name="sellingFeeFixed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sellingFeeFixed")]
    public float? SellingFeeFixed { get; set; }

    /// <summary>
    /// Gets or Sets Vpa
    /// </summary>
    [DataMember(Name="vpa", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "vpa")]
    public float? Vpa { get; set; }

    /// <summary>
    /// Gets or Sets AgentPriceOpinion
    /// </summary>
    [DataMember(Name="agentPriceOpinion", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "agentPriceOpinion")]
    public float? AgentPriceOpinion { get; set; }

    /// <summary>
    /// Gets or Sets RateableValue
    /// </summary>
    [DataMember(Name="rateableValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rateableValue")]
    public long? RateableValue { get; set; }

    /// <summary>
    /// Gets or Sets LandValue
    /// </summary>
    [DataMember(Name="landValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "landValue")]
    public long? LandValue { get; set; }

    /// <summary>
    /// Gets or Sets ImprovementValue
    /// </summary>
    [DataMember(Name="improvementValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "improvementValue")]
    public long? ImprovementValue { get; set; }

    /// <summary>
    /// Gets or Sets MethodOfsale
    /// </summary>
    [DataMember(Name="methodOfsale", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "methodOfsale")]
    public ID MethodOfsale { get; set; }

    /// <summary>
    /// Gets or Sets AuthorityType
    /// </summary>
    [DataMember(Name="authorityType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authorityType")]
    public ID AuthorityType { get; set; }

    /// <summary>
    /// Gets or Sets TenureOrTitleType
    /// </summary>
    [DataMember(Name="tenureOrTitleType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenureOrTitleType")]
    public ID TenureOrTitleType { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddUpdateLandProperty {\n");
      sb.Append("  Rates: ").Append(Rates).Append("\n");
      sb.Append("  ExternalLinks: ").Append(ExternalLinks).Append("\n");
      sb.Append("  PriceOnApplication: ").Append(PriceOnApplication).Append("\n");
      sb.Append("  AuthorityStart: ").Append(AuthorityStart).Append("\n");
      sb.Append("  AuthorityEnd: ").Append(AuthorityEnd).Append("\n");
      sb.Append("  SellingFeePercent: ").Append(SellingFeePercent).Append("\n");
      sb.Append("  SellingFeeFixed: ").Append(SellingFeeFixed).Append("\n");
      sb.Append("  Vpa: ").Append(Vpa).Append("\n");
      sb.Append("  AgentPriceOpinion: ").Append(AgentPriceOpinion).Append("\n");
      sb.Append("  RateableValue: ").Append(RateableValue).Append("\n");
      sb.Append("  LandValue: ").Append(LandValue).Append("\n");
      sb.Append("  ImprovementValue: ").Append(ImprovementValue).Append("\n");
      sb.Append("  MethodOfsale: ").Append(MethodOfsale).Append("\n");
      sb.Append("  AuthorityType: ").Append(AuthorityType).Append("\n");
      sb.Append("  TenureOrTitleType: ").Append(TenureOrTitleType).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public  new string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
