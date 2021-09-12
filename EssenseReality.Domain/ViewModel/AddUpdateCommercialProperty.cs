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
  public class AddUpdateCommercialProperty : AddUpdateProperty {
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
      sb.Append("class AddUpdateCommercialProperty {\n");
      sb.Append("  CarSpaces: ").Append(CarSpaces).Append("\n");
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
