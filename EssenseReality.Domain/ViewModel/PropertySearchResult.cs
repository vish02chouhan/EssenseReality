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
  public class PropertySearchResult {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

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
    /// Gets or Sets CommercialListingType
    /// </summary>
    [DataMember(Name="commercialListingType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "commercialListingType")]
    public string CommercialListingType { get; set; }

    /// <summary>
    /// Gets or Sets _Class
    /// </summary>
    [DataMember(Name="class", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "class")]
    public PropertyClass _Class { get; set; }

    /// <summary>
    /// Gets or Sets SaleLife
    /// </summary>
    [DataMember(Name="saleLife", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "saleLife")]
    public PropertySearchResultSaleLife SaleLife { get; set; }

    /// <summary>
    /// Gets or Sets LeaseLife
    /// </summary>
    [DataMember(Name="leaseLife", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "leaseLife")]
    public PropertySearchResultSaleLife LeaseLife { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PropertySearchResult {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  SaleLifeId: ").Append(SaleLifeId).Append("\n");
      sb.Append("  LeaseLifeId: ").Append(LeaseLifeId).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
      sb.Append("  DisplayAddress: ").Append(DisplayAddress).Append("\n");
      sb.Append("  CommercialListingType: ").Append(CommercialListingType).Append("\n");
      sb.Append("  _Class: ").Append(_Class).Append("\n");
      sb.Append("  SaleLife: ").Append(SaleLife).Append("\n");
      sb.Append("  LeaseLife: ").Append(LeaseLife).Append("\n");
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