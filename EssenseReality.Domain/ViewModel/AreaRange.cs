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
  public class AreaRange {
    /// <summary>
    /// Gets or Sets Minimum
    /// </summary>
    [DataMember(Name="minimum", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minimum")]
    public long? Minimum { get; set; }

    /// <summary>
    /// Gets or Sets Maximum
    /// </summary>
    [DataMember(Name="maximum", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maximum")]
    public long? Maximum { get; set; }

    /// <summary>
    /// Gets or Sets Units
    /// </summary>
    [DataMember(Name="units", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "units")]
    public string Units { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AreaRange {\n");
      sb.Append("  Minimum: ").Append(Minimum).Append("\n");
      sb.Append("  Maximum: ").Append(Maximum).Append("\n");
      sb.Append("  Units: ").Append(Units).Append("\n");
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
