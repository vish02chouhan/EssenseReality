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
  public class PropertyFeatureGrouping {
    /// <summary>
    /// Gets or Sets GroupName
    /// </summary>
    [DataMember(Name="groupName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "groupName")]
    public string GroupName { get; set; }

    /// <summary>
    /// Gets or Sets GroupDisplayName
    /// </summary>
    [DataMember(Name="groupDisplayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "groupDisplayName")]
    public string GroupDisplayName { get; set; }

    /// <summary>
    /// Gets or Sets Features
    /// </summary>
    [DataMember(Name="features", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "features")]
    public List<PropertyFeature> Features { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PropertyFeatureGrouping {\n");
      sb.Append("  GroupName: ").Append(GroupName).Append("\n");
      sb.Append("  GroupDisplayName: ").Append(GroupDisplayName).Append("\n");
      sb.Append("  Features: ").Append(Features).Append("\n");
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