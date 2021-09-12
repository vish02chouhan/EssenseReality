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
  public class CommercialDealSale : CommercialDeal {
    /// <summary>
    /// Gets or Sets Purchasers
    /// </summary>
    [DataMember(Name="purchasers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "purchasers")]
    public List<ContactMinimal> Purchasers { get; set; }

    /// <summary>
    /// Gets or Sets SalePrice
    /// </summary>
    [DataMember(Name="salePrice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "salePrice")]
    public float? SalePrice { get; set; }

    /// <summary>
    /// Gets or Sets VacantPossession
    /// </summary>
    [DataMember(Name="vacantPossession", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "vacantPossession")]
    public bool? VacantPossession { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CommercialDealSale {\n");
      sb.Append("  Purchasers: ").Append(Purchasers).Append("\n");
      sb.Append("  SalePrice: ").Append(SalePrice).Append("\n");
      sb.Append("  VacantPossession: ").Append(VacantPossession).Append("\n");
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
