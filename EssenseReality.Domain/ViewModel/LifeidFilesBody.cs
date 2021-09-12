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
  public class LifeidFilesBody {
    /// <summary>
    /// For a lease life, to which tenancy does the file relate
    /// </summary>
    /// <value>For a lease life, to which tenancy does the file relate</value>
    [DataMember(Name="tenancyId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenancyId")]
    public long? TenancyId { get; set; }

    /// <summary>
    /// Assign file to these folders
    /// </summary>
    /// <value>Assign file to these folders</value>
    [DataMember(Name="folders", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "folders")]
    public List<long?> Folders { get; set; }

    /// <summary>
    /// The file to be uploaded
    /// </summary>
    /// <value>The file to be uploaded</value>
    [DataMember(Name="file", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "file")]
    public byte[] File { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LifeidFilesBody {\n");
      sb.Append("  TenancyId: ").Append(TenancyId).Append("\n");
      sb.Append("  Folders: ").Append(Folders).Append("\n");
      sb.Append("  File: ").Append(File).Append("\n");
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
