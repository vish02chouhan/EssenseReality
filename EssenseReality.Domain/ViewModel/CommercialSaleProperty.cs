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
  public class CommercialSaleProperty : CommercialProperty {
    /// <summary>
    /// Gets or Sets PriceQualifier
    /// </summary>
    [DataMember(Name="priceQualifier", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "priceQualifier")]
    public PriceQualifier PriceQualifier { get; set; }

    /// <summary>
    /// Gets or Sets TenureOrTitleType
    /// </summary>
    [DataMember(Name="tenureOrTitleType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenureOrTitleType")]
    public TenureOrTitleType TenureOrTitleType { get; set; }

    /// <summary>
    /// Gets or Sets Branch
    /// </summary>
    [DataMember(Name="branch", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "branch")]
    public AccountBranch Branch { get; set; }

    /// <summary>
    /// Gets or Sets Tenanted
    /// </summary>
    [DataMember(Name="tenanted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenanted")]
    public bool? Tenanted { get; set; }

    /// <summary>
    /// Gets or Sets TenancyDetails
    /// </summary>
    [DataMember(Name="tenancyDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenancyDetails")]
    public string TenancyDetails { get; set; }

    /// <summary>
    /// Gets or Sets TenancyStart
    /// </summary>
    [DataMember(Name="tenancyStart", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenancyStart")]
    public DateTime? TenancyStart { get; set; }

    /// <summary>
    /// Gets or Sets TenancyStop
    /// </summary>
    [DataMember(Name="tenancyStop", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenancyStop")]
    public DateTime? TenancyStop { get; set; }

    /// <summary>
    /// Gets or Sets TenantName
    /// </summary>
    [DataMember(Name="tenantName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenantName")]
    public string TenantName { get; set; }

    /// <summary>
    /// Gets or Sets TenantPhone
    /// </summary>
    [DataMember(Name="tenantPhone", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenantPhone")]
    public string TenantPhone { get; set; }

    /// <summary>
    /// Gets or Sets TenantEmail
    /// </summary>
    [DataMember(Name="tenantEmail", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenantEmail")]
    public string TenantEmail { get; set; }

    /// <summary>
    /// Gets or Sets Rates
    /// </summary>
    [DataMember(Name="rates", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rates")]
    public SalePropertyRates Rates { get; set; }

    /// <summary>
    /// Gets or Sets MobileMarketingDescription
    /// </summary>
    [DataMember(Name="mobileMarketingDescription", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mobileMarketingDescription")]
    public string MobileMarketingDescription { get; set; }

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
    /// Gets or Sets PublishedToWeb
    /// </summary>
    [DataMember(Name="publishedToWeb", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "publishedToWeb")]
    public DateTime? PublishedToWeb { get; set; }

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
    public MethodOfSale MethodOfsale { get; set; }

    /// <summary>
    /// Gets or Sets AuthorityType
    /// </summary>
    [DataMember(Name="authorityType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authorityType")]
    public AuthorityType AuthorityType { get; set; }

    /// <summary>
    /// Gets or Sets WebId
    /// </summary>
    [DataMember(Name="webId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "webId")]
    public string WebId { get; set; }

    /// <summary>
    /// Gets or Sets AuctionDetails
    /// </summary>
    [DataMember(Name="auctionDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "auctionDetails")]
    public AuctionDetails AuctionDetails { get; set; }

    /// <summary>
    /// Gets or Sets TenderDetails
    /// </summary>
    [DataMember(Name="tenderDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenderDetails")]
    public TenderDetails TenderDetails { get; set; }

    /// <summary>
    /// Gets or Sets SetSaleDateDetails
    /// </summary>
    [DataMember(Name="setSaleDateDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "setSaleDateDetails")]
    public SetSaleDateDetails SetSaleDateDetails { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CommercialSaleProperty {\n");
      sb.Append("  PriceQualifier: ").Append(PriceQualifier).Append("\n");
      sb.Append("  TenureOrTitleType: ").Append(TenureOrTitleType).Append("\n");
      sb.Append("  Branch: ").Append(Branch).Append("\n");
      sb.Append("  Tenanted: ").Append(Tenanted).Append("\n");
      sb.Append("  TenancyDetails: ").Append(TenancyDetails).Append("\n");
      sb.Append("  TenancyStart: ").Append(TenancyStart).Append("\n");
      sb.Append("  TenancyStop: ").Append(TenancyStop).Append("\n");
      sb.Append("  TenantName: ").Append(TenantName).Append("\n");
      sb.Append("  TenantPhone: ").Append(TenantPhone).Append("\n");
      sb.Append("  TenantEmail: ").Append(TenantEmail).Append("\n");
      sb.Append("  Rates: ").Append(Rates).Append("\n");
      sb.Append("  MobileMarketingDescription: ").Append(MobileMarketingDescription).Append("\n");
      sb.Append("  ExternalLinks: ").Append(ExternalLinks).Append("\n");
      sb.Append("  PriceOnApplication: ").Append(PriceOnApplication).Append("\n");
      sb.Append("  AuthorityStart: ").Append(AuthorityStart).Append("\n");
      sb.Append("  AuthorityEnd: ").Append(AuthorityEnd).Append("\n");
      sb.Append("  PublishedToWeb: ").Append(PublishedToWeb).Append("\n");
      sb.Append("  SellingFeePercent: ").Append(SellingFeePercent).Append("\n");
      sb.Append("  SellingFeeFixed: ").Append(SellingFeeFixed).Append("\n");
      sb.Append("  Vpa: ").Append(Vpa).Append("\n");
      sb.Append("  AgentPriceOpinion: ").Append(AgentPriceOpinion).Append("\n");
      sb.Append("  RateableValue: ").Append(RateableValue).Append("\n");
      sb.Append("  LandValue: ").Append(LandValue).Append("\n");
      sb.Append("  ImprovementValue: ").Append(ImprovementValue).Append("\n");
      sb.Append("  MethodOfsale: ").Append(MethodOfsale).Append("\n");
      sb.Append("  AuthorityType: ").Append(AuthorityType).Append("\n");
      sb.Append("  WebId: ").Append(WebId).Append("\n");
      sb.Append("  AuctionDetails: ").Append(AuctionDetails).Append("\n");
      sb.Append("  TenderDetails: ").Append(TenderDetails).Append("\n");
      sb.Append("  SetSaleDateDetails: ").Append(SetSaleDateDetails).Append("\n");
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
