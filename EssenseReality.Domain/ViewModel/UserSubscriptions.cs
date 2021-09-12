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
  public class UserSubscriptions {
    /// <summary>
    /// Gets or Sets Corelogic
    /// </summary>
    [DataMember(Name="corelogic", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "corelogic")]
    public bool? Corelogic { get; set; }

    /// <summary>
    /// Gets or Sets Pricefinder
    /// </summary>
    [DataMember(Name="pricefinder", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pricefinder")]
    public bool? Pricefinder { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UserSubscriptions {\n");
      sb.Append("  Corelogic: ").Append(Corelogic).Append("\n");
      sb.Append("  Pricefinder: ").Append(Pricefinder).Append("\n");
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
