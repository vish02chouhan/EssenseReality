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
  public class ContactAndMarketingUser {
    /// <summary>
    /// Gets or Sets MarketingUser
    /// </summary>
    [DataMember(Name="marketingUser", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "marketingUser")]
    public MarketingUser MarketingUser { get; set; }

    /// <summary>
    /// Gets or Sets Contact
    /// </summary>
    [DataMember(Name="contact", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contact")]
    public ID Contact { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ContactAndMarketingUser {\n");
      sb.Append("  MarketingUser: ").Append(MarketingUser).Append("\n");
      sb.Append("  Contact: ").Append(Contact).Append("\n");
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