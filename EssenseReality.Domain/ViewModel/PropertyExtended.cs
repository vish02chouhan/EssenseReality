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
  public class PropertyExtended : Property {
    /// <summary>
    /// Gets or Sets AccessBy
    /// </summary>
    [DataMember(Name="accessBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessBy")]
    public List<Access> AccessBy { get; set; }

    /// <summary>
    /// Gets or Sets EditableBy
    /// </summary>
    [DataMember(Name="editableBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "editableBy")]
    public List<Access> EditableBy { get; set; }

    /// <summary>
    /// Gets or Sets Keys
    /// </summary>
    [DataMember(Name="keys", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "keys")]
    public List<PropertyKey> Keys { get; set; }

    /// <summary>
    /// Gets or Sets LeaseHistory
    /// </summary>
    [DataMember(Name="leaseHistory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "leaseHistory")]
    public List<LeaseHistory> LeaseHistory { get; set; }

    /// <summary>
    /// Gets or Sets SaleHistory
    /// </summary>
    [DataMember(Name="saleHistory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "saleHistory")]
    public List<SaleHistory> SaleHistory { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PropertyExtended {\n");
      sb.Append("  AccessBy: ").Append(AccessBy).Append("\n");
      sb.Append("  EditableBy: ").Append(EditableBy).Append("\n");
      sb.Append("  Keys: ").Append(Keys).Append("\n");
      sb.Append("  LeaseHistory: ").Append(LeaseHistory).Append("\n");
      sb.Append("  SaleHistory: ").Append(SaleHistory).Append("\n");
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
