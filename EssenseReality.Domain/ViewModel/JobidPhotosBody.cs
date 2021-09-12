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
  public class JobidPhotosBody {
    /// <summary>
    /// The description of the maintenance photo
    /// </summary>
    /// <value>The description of the maintenance photo</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// The photo to be uploaded
    /// </summary>
    /// <value>The photo to be uploaded</value>
    [DataMember(Name="photo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "photo")]
    public byte[] Photo { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class JobidPhotosBody {\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
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
