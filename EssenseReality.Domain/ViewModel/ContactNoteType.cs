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
  public class ContactNoteType {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets Colour
    /// </summary>
    [DataMember(Name="colour", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "colour")]
    public string Colour { get; set; }

    /// <summary>
    /// Gets or Sets DefaultReadOnly
    /// </summary>
    [DataMember(Name="defaultReadOnly", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "defaultReadOnly")]
    public bool? DefaultReadOnly { get; set; }

    /// <summary>
    /// Gets or Sets Pinned
    /// </summary>
    [DataMember(Name="pinned", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pinned")]
    public bool? Pinned { get; set; }

    /// <summary>
    /// Gets or Sets Purpose
    /// </summary>
    [DataMember(Name="purpose", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purpose")]
    public ContactNoteTypePurpose Purpose { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ContactNoteType {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Colour: ").Append(Colour).Append("\n");
      sb.Append("  DefaultReadOnly: ").Append(DefaultReadOnly).Append("\n");
      sb.Append("  Pinned: ").Append(Pinned).Append("\n");
      sb.Append("  Purpose: ").Append(Purpose).Append("\n");
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
