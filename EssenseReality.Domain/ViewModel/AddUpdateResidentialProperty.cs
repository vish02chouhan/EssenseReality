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
  public class AddUpdateResidentialProperty : AddUpdateProperty {
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
    /// Gets or Sets Garages
    /// </summary>
    [DataMember(Name="garages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "garages")]
    public long? Garages { get; set; }

    /// <summary>
    /// Gets or Sets Carports
    /// </summary>
    [DataMember(Name="carports", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carports")]
    public long? Carports { get; set; }

    /// <summary>
    /// Gets or Sets OpenSpaces
    /// </summary>
    [DataMember(Name="openSpaces", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "openSpaces")]
    public long? OpenSpaces { get; set; }

    /// <summary>
    /// Gets or Sets Ensuites
    /// </summary>
    [DataMember(Name="ensuites", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ensuites")]
    public long? Ensuites { get; set; }

    /// <summary>
    /// Gets or Sets Toilets
    /// </summary>
    [DataMember(Name="toilets", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "toilets")]
    public long? Toilets { get; set; }

    /// <summary>
    /// Gets or Sets ReceptionRooms
    /// </summary>
    [DataMember(Name="receptionRooms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "receptionRooms")]
    public long? ReceptionRooms { get; set; }

    /// <summary>
    /// Gets or Sets FloorArea
    /// </summary>
    [DataMember(Name="floorArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "floorArea")]
    public Area FloorArea { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddUpdateResidentialProperty {\n");
      sb.Append("  Bed: ").Append(Bed).Append("\n");
      sb.Append("  Bath: ").Append(Bath).Append("\n");
      sb.Append("  Garages: ").Append(Garages).Append("\n");
      sb.Append("  Carports: ").Append(Carports).Append("\n");
      sb.Append("  OpenSpaces: ").Append(OpenSpaces).Append("\n");
      sb.Append("  Ensuites: ").Append(Ensuites).Append("\n");
      sb.Append("  Toilets: ").Append(Toilets).Append("\n");
      sb.Append("  ReceptionRooms: ").Append(ReceptionRooms).Append("\n");
      sb.Append("  FloorArea: ").Append(FloorArea).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
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
