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
  public class ResidentialSoldPropertyExtended : ResidentialSalePropertyExtended {
    /// <summary>
    /// Gets or Sets SaleDetails
    /// </summary>
    [DataMember(Name="saleDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "saleDetails")]
    public SaleHistory SaleDetails { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResidentialSoldPropertyExtended {\n");
      sb.Append("  SaleDetails: ").Append(SaleDetails).Append("\n");
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