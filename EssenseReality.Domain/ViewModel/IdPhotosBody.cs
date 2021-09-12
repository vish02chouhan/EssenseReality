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
  public class IdPhotosBody {
    /// <summary>
    /// The photo to be uploaded (GIF/PNG/JPG only)
    /// </summary>
    /// <value>The photo to be uploaded (GIF/PNG/JPG only)</value>
    [DataMember(Name="photo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "photo")]
    public byte[] Photo { get; set; }

    /// <summary>
    /// The caption for the photo
    /// </summary>
    /// <value>The caption for the photo</value>
    [DataMember(Name="caption", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "caption")]
    public string Caption { get; set; }

    /// <summary>
    /// Is the photo published or unpublished
    /// </summary>
    /// <value>Is the photo published or unpublished</value>
    [DataMember(Name="published", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "published")]
    public bool? Published { get; set; }

    /// <summary>
    /// The type of photo
    /// </summary>
    /// <value>The type of photo</value>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class IdPhotosBody {\n");
      sb.Append("  Photo: ").Append(Photo).Append("\n");
      sb.Append("  Caption: ").Append(Caption).Append("\n");
      sb.Append("  Published: ").Append(Published).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
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
