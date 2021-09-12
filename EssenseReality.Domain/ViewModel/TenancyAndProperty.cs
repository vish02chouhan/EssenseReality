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
  public class TenancyAndProperty {
    /// <summary>
    /// Gets or Sets Property
    /// </summary>
    [DataMember(Name="property", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "property")]
    public TenancyAndPropertyProperty Property { get; set; }

    /// <summary>
    /// Gets or Sets Tenancy
    /// </summary>
    [DataMember(Name="tenancy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenancy")]
    public TenancyExtended Tenancy { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TenancyAndProperty {\n");
      sb.Append("  Property: ").Append(Property).Append("\n");
      sb.Append("  Tenancy: ").Append(Tenancy).Append("\n");
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
