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
  public class SaleHistory {
    /// <summary>
    /// Gets or Sets LifeId
    /// </summary>
    [DataMember(Name="lifeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lifeId")]
    public decimal? LifeId { get; set; }

    /// <summary>
    /// Gets or Sets IsReleasedSale
    /// </summary>
    [DataMember(Name="isReleasedSale", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isReleasedSale")]
    public bool? IsReleasedSale { get; set; }

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
    /// Gets or Sets ListingAuthority
    /// </summary>
    [DataMember(Name="listingAuthority", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "listingAuthority")]
    public DateTime? ListingAuthority { get; set; }

    /// <summary>
    /// Gets or Sets PublishedToWeb
    /// </summary>
    [DataMember(Name="publishedToWeb", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "publishedToWeb")]
    public DateTime? PublishedToWeb { get; set; }

    /// <summary>
    /// Gets or Sets Conditional
    /// </summary>
    [DataMember(Name="conditional", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "conditional")]
    public DateTime? Conditional { get; set; }

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
    /// Gets or Sets ReleaseDate
    /// </summary>
    [DataMember(Name="releaseDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "releaseDate")]
    public DateTime? ReleaseDate { get; set; }

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
    /// Gets or Sets SalePrice
    /// </summary>
    [DataMember(Name="salePrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "salePrice")]
    public float? SalePrice { get; set; }

    /// <summary>
    /// Gets or Sets ShowSalePrice
    /// </summary>
    [DataMember(Name="showSalePrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "showSalePrice")]
    public bool? ShowSalePrice { get; set; }

    /// <summary>
    /// Gets or Sets GrossCommissionExcGST
    /// </summary>
    [DataMember(Name="grossCommissionExcGST", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "grossCommissionExcGST")]
    public float? GrossCommissionExcGST { get; set; }

    /// <summary>
    /// Gets or Sets WebId
    /// </summary>
    [DataMember(Name="webId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "webId")]
    public string WebId { get; set; }

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
    /// Gets or Sets CommissionSplits
    /// </summary>
    [DataMember(Name="commissionSplits", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "commissionSplits")]
    public List<CommissionSplit> CommissionSplits { get; set; }

    /// <summary>
    /// Gets or Sets SoldType
    /// </summary>
    [DataMember(Name="soldType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "soldType")]
    public SoldType SoldType { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SaleHistory {\n");
      sb.Append("  LifeId: ").Append(LifeId).Append("\n");
      sb.Append("  IsReleasedSale: ").Append(IsReleasedSale).Append("\n");
      sb.Append("  Appraisal: ").Append(Appraisal).Append("\n");
      sb.Append("  AppraisalPriceLower: ").Append(AppraisalPriceLower).Append("\n");
      sb.Append("  AppraisalPriceUpper: ").Append(AppraisalPriceUpper).Append("\n");
      sb.Append("  ListingAuthority: ").Append(ListingAuthority).Append("\n");
      sb.Append("  PublishedToWeb: ").Append(PublishedToWeb).Append("\n");
      sb.Append("  Conditional: ").Append(Conditional).Append("\n");
      sb.Append("  Unconditional: ").Append(Unconditional).Append("\n");
      sb.Append("  Settlement: ").Append(Settlement).Append("\n");
      sb.Append("  ReleaseDate: ").Append(ReleaseDate).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  PortalStatus: ").Append(PortalStatus).Append("\n");
      sb.Append("  SalePrice: ").Append(SalePrice).Append("\n");
      sb.Append("  ShowSalePrice: ").Append(ShowSalePrice).Append("\n");
      sb.Append("  GrossCommissionExcGST: ").Append(GrossCommissionExcGST).Append("\n");
      sb.Append("  WebId: ").Append(WebId).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Modified: ").Append(Modified).Append("\n");
      sb.Append("  ContactStaff: ").Append(ContactStaff).Append("\n");
      sb.Append("  CommissionSplits: ").Append(CommissionSplits).Append("\n");
      sb.Append("  SoldType: ").Append(SoldType).Append("\n");
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
