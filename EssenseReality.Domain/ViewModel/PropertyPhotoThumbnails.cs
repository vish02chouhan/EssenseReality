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
  public class PropertyPhotoThumbnails {
    /// <summary>
    /// Gets or Sets Thumb180
    /// </summary>
    [DataMember(Name="thumb_180", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "thumb_180")]
    public string Thumb180 { get; set; }

    /// <summary>
    /// Gets or Sets Thumb1024
    /// </summary>
    [DataMember(Name="thumb_1024", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "thumb_1024")]
    public string Thumb1024 { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PropertyPhotoThumbnails {\n");
      sb.Append("  Thumb180: ").Append(Thumb180).Append("\n");
      sb.Append("  Thumb1024: ").Append(Thumb1024).Append("\n");
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
