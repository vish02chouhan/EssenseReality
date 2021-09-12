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
  public class ContactExtended : Contact {
    /// <summary>
    /// Gets or Sets AccessBy
    /// </summary>
    [DataMember(Name="accessBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessBy")]
    public List<Access> AccessBy { get; set; }

    /// <summary>
    /// Gets or Sets SourceOfEnquiry
    /// </summary>
    [DataMember(Name="sourceOfEnquiry", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sourceOfEnquiry")]
    public EnquirySource SourceOfEnquiry { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ContactExtended {\n");
      sb.Append("  AccessBy: ").Append(AccessBy).Append("\n");
      sb.Append("  SourceOfEnquiry: ").Append(SourceOfEnquiry).Append("\n");
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
