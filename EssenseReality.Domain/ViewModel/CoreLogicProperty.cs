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
  public class CoreLogicProperty {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets Address
    /// </summary>
    [DataMember(Name="address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "address")]
    public Address Address { get; set; }

    /// <summary>
    /// Gets or Sets Bed
    /// </summary>
    [DataMember(Name="bed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bed")]
    public long? Bed { get; set; }

    /// <summary>
    /// Gets or Sets Bath
    /// </summary>
    [DataMember(Name="bath", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bath")]
    public long? Bath { get; set; }

    /// <summary>
    /// Gets or Sets CarSpaces
    /// </summary>
    [DataMember(Name="carSpaces", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carSpaces")]
    public long? CarSpaces { get; set; }

    /// <summary>
    /// Gets or Sets FloorArea
    /// </summary>
    [DataMember(Name="floorArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "floorArea")]
    public Area FloorArea { get; set; }

    /// <summary>
    /// Gets or Sets LandArea
    /// </summary>
    [DataMember(Name="landArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "landArea")]
    public Area LandArea { get; set; }

    /// <summary>
    /// Gets or Sets VolumeNumber
    /// </summary>
    [DataMember(Name="volumeNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "volumeNumber")]
    public string VolumeNumber { get; set; }

    /// <summary>
    /// Gets or Sets FolioNumber
    /// </summary>
    [DataMember(Name="folioNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "folioNumber")]
    public string FolioNumber { get; set; }

    /// <summary>
    /// Gets or Sets Frontage
    /// </summary>
    [DataMember(Name="frontage", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "frontage")]
    public float? Frontage { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CoreLogicProperty {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
      sb.Append("  Bed: ").Append(Bed).Append("\n");
      sb.Append("  Bath: ").Append(Bath).Append("\n");
      sb.Append("  CarSpaces: ").Append(CarSpaces).Append("\n");
      sb.Append("  FloorArea: ").Append(FloorArea).Append("\n");
      sb.Append("  LandArea: ").Append(LandArea).Append("\n");
      sb.Append("  VolumeNumber: ").Append(VolumeNumber).Append("\n");
      sb.Append("  FolioNumber: ").Append(FolioNumber).Append("\n");
      sb.Append("  Frontage: ").Append(Frontage).Append("\n");
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
