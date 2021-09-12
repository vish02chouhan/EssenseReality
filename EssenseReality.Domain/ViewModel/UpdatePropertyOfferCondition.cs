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
  public class UpdatePropertyOfferCondition {
    /// <summary>
    /// Gets or Sets Condition
    /// </summary>
    [DataMember(Name="condition", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "condition")]
    public ID Condition { get; set; }

    /// <summary>
    /// Gets or Sets User
    /// </summary>
    [DataMember(Name="user", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "user")]
    public ID User { get; set; }

    /// <summary>
    /// Gets or Sets Due
    /// </summary>
    [DataMember(Name="due", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "due")]
    public DateTime? Due { get; set; }

    /// <summary>
    /// Gets or Sets Completed
    /// </summary>
    [DataMember(Name="completed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "completed")]
    public bool? Completed { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdatePropertyOfferCondition {\n");
      sb.Append("  Condition: ").Append(Condition).Append("\n");
      sb.Append("  User: ").Append(User).Append("\n");
      sb.Append("  Due: ").Append(Due).Append("\n");
      sb.Append("  Completed: ").Append(Completed).Append("\n");
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
