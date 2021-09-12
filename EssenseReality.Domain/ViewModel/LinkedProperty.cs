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
  public class LinkedProperty {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

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
    /// Gets or Sets Relationship
    /// </summary>
    [DataMember(Name="relationship", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "relationship")]
    public string Relationship { get; set; }

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
    /// Gets or Sets _Class
    /// </summary>
    [DataMember(Name="class", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "class")]
    public PropertyClass _Class { get; set; }

    /// <summary>
    /// Gets or Sets Photo
    /// </summary>
    [DataMember(Name="photo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "photo")]
    public PropertyPhoto Photo { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LinkedProperty {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
      sb.Append("  DisplayAddress: ").Append(DisplayAddress).Append("\n");
      sb.Append("  SaleLifeId: ").Append(SaleLifeId).Append("\n");
      sb.Append("  LeaseLifeId: ").Append(LeaseLifeId).Append("\n");
      sb.Append("  Relationship: ").Append(Relationship).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  PortalStatus: ").Append(PortalStatus).Append("\n");
      sb.Append("  _Class: ").Append(_Class).Append("\n");
      sb.Append("  Photo: ").Append(Photo).Append("\n");
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
