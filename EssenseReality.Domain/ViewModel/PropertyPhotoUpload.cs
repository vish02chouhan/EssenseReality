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
  public class PropertyPhotoUpload {
    /// <summary>
    /// Gets or Sets Filesize
    /// </summary>
    [DataMember(Name="filesize", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "filesize")]
    public long? Filesize { get; set; }

    /// <summary>
    /// Gets or Sets Width
    /// </summary>
    [DataMember(Name="width", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "width")]
    public long? Width { get; set; }

    /// <summary>
    /// Gets or Sets Height
    /// </summary>
    [DataMember(Name="height", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "height")]
    public long? Height { get; set; }

    /// <summary>
    /// Gets or Sets Caption
    /// </summary>
    [DataMember(Name="caption", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "caption")]
    public string Caption { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or Sets ContentType
    /// </summary>
    [DataMember(Name="contentType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contentType")]
    public string ContentType { get; set; }

    /// <summary>
    /// Gets or Sets UserFilename
    /// </summary>
    [DataMember(Name="userFilename", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userFilename")]
    public string UserFilename { get; set; }

    /// <summary>
    /// Gets or Sets Published
    /// </summary>
    [DataMember(Name="published", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "published")]
    public bool? Published { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PropertyPhotoUpload {\n");
      sb.Append("  Filesize: ").Append(Filesize).Append("\n");
      sb.Append("  Width: ").Append(Width).Append("\n");
      sb.Append("  Height: ").Append(Height).Append("\n");
      sb.Append("  Caption: ").Append(Caption).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  ContentType: ").Append(ContentType).Append("\n");
      sb.Append("  UserFilename: ").Append(UserFilename).Append("\n");
      sb.Append("  Published: ").Append(Published).Append("\n");
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