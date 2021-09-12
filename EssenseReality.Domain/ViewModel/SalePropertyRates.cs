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
  public class SalePropertyRates {
    /// <summary>
    /// Gets or Sets Water
    /// </summary>
    [DataMember(Name="water", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "water")]
    public Rate Water { get; set; }

    /// <summary>
    /// Gets or Sets Council
    /// </summary>
    [DataMember(Name="council", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "council")]
    public Rate Council { get; set; }

    /// <summary>
    /// Gets or Sets Strata
    /// </summary>
    [DataMember(Name="strata", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "strata")]
    public Rate Strata { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SalePropertyRates {\n");
      sb.Append("  Water: ").Append(Water).Append("\n");
      sb.Append("  Council: ").Append(Council).Append("\n");
      sb.Append("  Strata: ").Append(Strata).Append("\n");
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
