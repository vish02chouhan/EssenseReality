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
  public class AddUpdateProperty {
    /// <summary>
    /// Gets or Sets Building
    /// </summary>
    [DataMember(Name="building", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "building")]
    public ID Building { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public ID Type { get; set; }

    /// <summary>
    /// Gets or Sets Address
    /// </summary>
    [DataMember(Name="address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "address")]
    public UpdateAddress Address { get; set; }

    /// <summary>
    /// Gets or Sets ReferenceID
    /// </summary>
    [DataMember(Name="referenceID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "referenceID")]
    public string ReferenceID { get; set; }

    /// <summary>
    /// Gets or Sets SearchPrice
    /// </summary>
    [DataMember(Name="searchPrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "searchPrice")]
    public float? SearchPrice { get; set; }

    /// <summary>
    /// Gets or Sets DisplayPrice
    /// </summary>
    [DataMember(Name="displayPrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "displayPrice")]
    public string DisplayPrice { get; set; }

    /// <summary>
    /// Gets or Sets Heading
    /// </summary>
    [DataMember(Name="heading", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "heading")]
    public string Heading { get; set; }

    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or Sets BrochureDescription
    /// </summary>
    [DataMember(Name="brochureDescription", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "brochureDescription")]
    public string BrochureDescription { get; set; }

    /// <summary>
    /// Gets or Sets LandArea
    /// </summary>
    [DataMember(Name="landArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "landArea")]
    public Area LandArea { get; set; }

    /// <summary>
    /// Gets or Sets VolumeNumber
    /// </summary>
    [DataMember(Name="volumeNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "volumeNumber")]
    public string VolumeNumber { get; set; }

    /// <summary>
    /// Gets or Sets FolioNumber
    /// </summary>
    [DataMember(Name="folioNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "folioNumber")]
    public string FolioNumber { get; set; }

    /// <summary>
    /// Gets or Sets CorelogicId
    /// </summary>
    [DataMember(Name="corelogicId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "corelogicId")]
    public long? CorelogicId { get; set; }

    /// <summary>
    /// Gets or Sets YearBuilt
    /// </summary>
    [DataMember(Name="yearBuilt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "yearBuilt")]
    public long? YearBuilt { get; set; }

    /// <summary>
    /// Gets or Sets AccessBy
    /// </summary>
    [DataMember(Name="accessBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessBy")]
    public List<ID> AccessBy { get; set; }

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
    /// Gets or Sets ContactStaff
    /// </summary>
    [DataMember(Name="contactStaff", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contactStaff")]
    public List<ID> ContactStaff { get; set; }

    /// <summary>
    /// Gets or Sets ExternalLinks
    /// </summary>
    [DataMember(Name="externalLinks", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "externalLinks")]
    public List<AddUpdateExternalLink> ExternalLinks { get; set; }

    /// <summary>
    /// Gets or Sets MobileMarketingDescription
    /// </summary>
    [DataMember(Name="mobileMarketingDescription", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mobileMarketingDescription")]
    public string MobileMarketingDescription { get; set; }

    /// <summary>
    /// Gets or Sets CertificateOfTitle
    /// </summary>
    [DataMember(Name="certificateOfTitle", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "certificateOfTitle")]
    public string CertificateOfTitle { get; set; }

    /// <summary>
    /// Gets or Sets LegalDescription
    /// </summary>
    [DataMember(Name="legalDescription", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "legalDescription")]
    public string LegalDescription { get; set; }

    /// <summary>
    /// Gets or Sets Rpdp
    /// </summary>
    [DataMember(Name="rpdp", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rpdp")]
    public string Rpdp { get; set; }

    /// <summary>
    /// Gets or Sets LotNumber
    /// </summary>
    [DataMember(Name="lotNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lotNumber")]
    public string LotNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddUpdateProperty {\n");
      sb.Append("  Building: ").Append(Building).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
      sb.Append("  ReferenceID: ").Append(ReferenceID).Append("\n");
      sb.Append("  SearchPrice: ").Append(SearchPrice).Append("\n");
      sb.Append("  DisplayPrice: ").Append(DisplayPrice).Append("\n");
      sb.Append("  Heading: ").Append(Heading).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  BrochureDescription: ").Append(BrochureDescription).Append("\n");
      sb.Append("  LandArea: ").Append(LandArea).Append("\n");
      sb.Append("  VolumeNumber: ").Append(VolumeNumber).Append("\n");
      sb.Append("  FolioNumber: ").Append(FolioNumber).Append("\n");
      sb.Append("  CorelogicId: ").Append(CorelogicId).Append("\n");
      sb.Append("  YearBuilt: ").Append(YearBuilt).Append("\n");
      sb.Append("  AccessBy: ").Append(AccessBy).Append("\n");
      sb.Append("  Appraisal: ").Append(Appraisal).Append("\n");
      sb.Append("  AppraisalPriceLower: ").Append(AppraisalPriceLower).Append("\n");
      sb.Append("  AppraisalPriceUpper: ").Append(AppraisalPriceUpper).Append("\n");
      sb.Append("  ContactStaff: ").Append(ContactStaff).Append("\n");
      sb.Append("  ExternalLinks: ").Append(ExternalLinks).Append("\n");
      sb.Append("  MobileMarketingDescription: ").Append(MobileMarketingDescription).Append("\n");
      sb.Append("  CertificateOfTitle: ").Append(CertificateOfTitle).Append("\n");
      sb.Append("  LegalDescription: ").Append(LegalDescription).Append("\n");
      sb.Append("  Rpdp: ").Append(Rpdp).Append("\n");
      sb.Append("  LotNumber: ").Append(LotNumber).Append("\n");
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
