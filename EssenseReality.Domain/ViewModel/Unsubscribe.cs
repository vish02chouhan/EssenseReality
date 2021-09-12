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
  public class Unsubscribe {
    /// <summary>
    /// Gets or Sets Email
    /// </summary>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public bool? Email { get; set; }

    /// <summary>
    /// Gets or Sets Sms
    /// </summary>
    [DataMember(Name="sms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sms")]
    public bool? Sms { get; set; }

    /// <summary>
    /// Gets or Sets Letters
    /// </summary>
    [DataMember(Name="letters", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "letters")]
    public bool? Letters { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Unsubscribe {\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  Sms: ").Append(Sms).Append("\n");
      sb.Append("  Letters: ").Append(Letters).Append("\n");
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
