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
  public class PropertyFileWithFolders : PropertyFile {
    /// <summary>
    /// Gets or Sets TenancyId
    /// </summary>
    [DataMember(Name="tenancyId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenancyId")]
    public long? TenancyId { get; set; }

    /// <summary>
    /// Gets or Sets Folders
    /// </summary>
    [DataMember(Name="folders", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "folders")]
    public List<PropertyFileFolder> Folders { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PropertyFileWithFolders {\n");
      sb.Append("  TenancyId: ").Append(TenancyId).Append("\n");
      sb.Append("  Folders: ").Append(Folders).Append("\n");
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
