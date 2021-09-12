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
  public class Property {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets Building
    /// </summary>
    [DataMember(Name="building", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "building")]
    public Building Building { get; set; }

    /// <summary>
    /// Gets or Sets _Class
    /// </summary>
    [DataMember(Name="class", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "class")]
    public PropertyClass _Class { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public PropertyType Type { get; set; }

    /// <summary>
    /// Gets or Sets Address
    /// </summary>
    [DataMember(Name="address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "address")]
    public Address Address { get; set; }

    /// <summary>
    /// Gets or Sets DisplayAddress
    /// </summary>
    [DataMember(Name="displayAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "displayAddress")]
    public string DisplayAddress { get; set; }

    /// <summary>
    /// Gets or Sets AddressVisibility
    /// </summary>
    [DataMember(Name="addressVisibility", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "addressVisibility")]
    public string AddressVisibility { get; set; }

    /// <summary>
    /// Gets or Sets ReferenceID
    /// </summary>
    [DataMember(Name="referenceID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "referenceID")]
    public string ReferenceID { get; set; }

    /// <summary>
    /// Gets or Sets Photos
    /// </summary>
    [DataMember(Name="photos", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "photos")]
    public List<PropertyPhoto> Photos { get; set; }

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
    /// Gets or Sets Frontage
    /// </summary>
    [DataMember(Name="frontage", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "frontage")]
    public float? Frontage { get; set; }

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
    /// Gets or Sets SaleLifeId
    /// </summary>
    [DataMember(Name="saleLifeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "saleLifeId")]
    public long? SaleLifeId { get; set; }

    /// <summary>
    /// Gets or Sets LeaseLifeId
    /// </summary>
    [DataMember(Name="leaseLifeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "leaseLifeId")]
    public long? LeaseLifeId { get; set; }

    /// <summary>
    /// Gets or Sets Geolocation
    /// </summary>
    [DataMember(Name="geolocation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "geolocation")]
    public Geolocation Geolocation { get; set; }

    /// <summary>
    /// Gets or Sets LotNumber
    /// </summary>
    [DataMember(Name="lotNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lotNumber")]
    public string LotNumber { get; set; }

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
    /// Gets or Sets CommercialListingType
    /// </summary>
    [DataMember(Name="commercialListingType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "commercialListingType")]
    public string CommercialListingType { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Property {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Building: ").Append(Building).Append("\n");
      sb.Append("  _Class: ").Append(_Class).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
      sb.Append("  DisplayAddress: ").Append(DisplayAddress).Append("\n");
      sb.Append("  AddressVisibility: ").Append(AddressVisibility).Append("\n");
      sb.Append("  ReferenceID: ").Append(ReferenceID).Append("\n");
      sb.Append("  Photos: ").Append(Photos).Append("\n");
      sb.Append("  SearchPrice: ").Append(SearchPrice).Append("\n");
      sb.Append("  DisplayPrice: ").Append(DisplayPrice).Append("\n");
      sb.Append("  Heading: ").Append(Heading).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  BrochureDescription: ").Append(BrochureDescription).Append("\n");
      sb.Append("  LandArea: ").Append(LandArea).Append("\n");
      sb.Append("  Frontage: ").Append(Frontage).Append("\n");
      sb.Append("  VolumeNumber: ").Append(VolumeNumber).Append("\n");
      sb.Append("  FolioNumber: ").Append(FolioNumber).Append("\n");
      sb.Append("  CorelogicId: ").Append(CorelogicId).Append("\n");
      sb.Append("  YearBuilt: ").Append(YearBuilt).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Modified: ").Append(Modified).Append("\n");
      sb.Append("  SaleLifeId: ").Append(SaleLifeId).Append("\n");
      sb.Append("  LeaseLifeId: ").Append(LeaseLifeId).Append("\n");
      sb.Append("  Geolocation: ").Append(Geolocation).Append("\n");
      sb.Append("  LotNumber: ").Append(LotNumber).Append("\n");
      sb.Append("  CertificateOfTitle: ").Append(CertificateOfTitle).Append("\n");
      sb.Append("  LegalDescription: ").Append(LegalDescription).Append("\n");
      sb.Append("  Rpdp: ").Append(Rpdp).Append("\n");
      sb.Append("  CommercialListingType: ").Append(CommercialListingType).Append("\n");
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
