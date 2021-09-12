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
  public class PropertyKey {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public decimal? Id { get; set; }

    /// <summary>
    /// Gets or Sets PropertyId
    /// </summary>
    [DataMember(Name="propertyId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "propertyId")]
    public decimal? PropertyId { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets IsKeyOut
    /// </summary>
    [DataMember(Name="isKeyOut", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isKeyOut")]
    public bool? IsKeyOut { get; set; }

    /// <summary>
    /// Gets or Sets Details
    /// </summary>
    [DataMember(Name="details", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "details")]
    public string Details { get; set; }

    /// <summary>
    /// Gets or Sets HexColour
    /// </summary>
    [DataMember(Name="hexColour", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "hexColour")]
    public string HexColour { get; set; }

    /// <summary>
    /// Gets or Sets Inserted
    /// </summary>
    [DataMember(Name="inserted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "inserted")]
    public DateTime? Inserted { get; set; }

    /// <summary>
    /// Gets or Sets Modified
    /// </summary>
    [DataMember(Name="modified", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modified")]
    public DateTime? Modified { get; set; }

    /// <summary>
    /// Gets or Sets KeyOutUser
    /// </summary>
    [DataMember(Name="keyOutUser", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "keyOutUser")]
    public Access KeyOutUser { get; set; }

    /// <summary>
    /// Gets or Sets KeyOutContact
    /// </summary>
    [DataMember(Name="keyOutContact", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "keyOutContact")]
    public ContactSearchResult KeyOutContact { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PropertyKey {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  PropertyId: ").Append(PropertyId).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  IsKeyOut: ").Append(IsKeyOut).Append("\n");
      sb.Append("  Details: ").Append(Details).Append("\n");
      sb.Append("  HexColour: ").Append(HexColour).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Modified: ").Append(Modified).Append("\n");
      sb.Append("  KeyOutUser: ").Append(KeyOutUser).Append("\n");
      sb.Append("  KeyOutContact: ").Append(KeyOutContact).Append("\n");
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
