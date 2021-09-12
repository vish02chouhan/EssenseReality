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
  public class HolidayRentalProperty : ResidentialProperty {
    /// <summary>
    /// Gets or Sets Branch
    /// </summary>
    [DataMember(Name="branch", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "branch")]
    public AccountBranch Branch { get; set; }

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
    /// Gets or Sets BondPrice
    /// </summary>
    [DataMember(Name="bondPrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bondPrice")]
    public float? BondPrice { get; set; }

    /// <summary>
    /// Gets or Sets ExpenditureLimit
    /// </summary>
    [DataMember(Name="expenditureLimit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "expenditureLimit")]
    public float? ExpenditureLimit { get; set; }

    /// <summary>
    /// Gets or Sets WebId
    /// </summary>
    [DataMember(Name="webId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "webId")]
    public string WebId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class HolidayRentalProperty {\n");
      sb.Append("  Branch: ").Append(Branch).Append("\n");
      sb.Append("  MobileMarketingDescription: ").Append(MobileMarketingDescription).Append("\n");
      sb.Append("  ExternalLinks: ").Append(ExternalLinks).Append("\n");
      sb.Append("  PriceOnApplication: ").Append(PriceOnApplication).Append("\n");
      sb.Append("  AuthorityStart: ").Append(AuthorityStart).Append("\n");
      sb.Append("  AuthorityEnd: ").Append(AuthorityEnd).Append("\n");
      sb.Append("  BondPrice: ").Append(BondPrice).Append("\n");
      sb.Append("  ExpenditureLimit: ").Append(ExpenditureLimit).Append("\n");
      sb.Append("  WebId: ").Append(WebId).Append("\n");
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
