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
  public class AccountOpeningHours {
    /// <summary>
    /// Gets or Sets Sunday
    /// </summary>
    [DataMember(Name="sunday", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sunday")]
    public string Sunday { get; set; }

    /// <summary>
    /// Gets or Sets Monday
    /// </summary>
    [DataMember(Name="monday", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "monday")]
    public string Monday { get; set; }

    /// <summary>
    /// Gets or Sets Tuesday
    /// </summary>
    [DataMember(Name="tuesday", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tuesday")]
    public string Tuesday { get; set; }

    /// <summary>
    /// Gets or Sets Wednesday
    /// </summary>
    [DataMember(Name="wednesday", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "wednesday")]
    public string Wednesday { get; set; }

    /// <summary>
    /// Gets or Sets Thursday
    /// </summary>
    [DataMember(Name="thursday", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "thursday")]
    public string Thursday { get; set; }

    /// <summary>
    /// Gets or Sets Friday
    /// </summary>
    [DataMember(Name="friday", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "friday")]
    public string Friday { get; set; }

    /// <summary>
    /// Gets or Sets Saturday
    /// </summary>
    [DataMember(Name="saturday", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "saturday")]
    public string Saturday { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AccountOpeningHours {\n");
      sb.Append("  Sunday: ").Append(Sunday).Append("\n");
      sb.Append("  Monday: ").Append(Monday).Append("\n");
      sb.Append("  Tuesday: ").Append(Tuesday).Append("\n");
      sb.Append("  Wednesday: ").Append(Wednesday).Append("\n");
      sb.Append("  Thursday: ").Append(Thursday).Append("\n");
      sb.Append("  Friday: ").Append(Friday).Append("\n");
      sb.Append("  Saturday: ").Append(Saturday).Append("\n");
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
