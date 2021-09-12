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
  public class CommercialSalePropertyExtended : CommercialPropertyExtended {
    /// <summary>
    /// Gets or Sets AuctionDetails
    /// </summary>
    [DataMember(Name="auctionDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "auctionDetails")]
    public AuctionDetails AuctionDetails { get; set; }

    /// <summary>
    /// Gets or Sets TenderDetails
    /// </summary>
    [DataMember(Name="tenderDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenderDetails")]
    public TenderDetails TenderDetails { get; set; }

    /// <summary>
    /// Gets or Sets SetSaleDateDetails
    /// </summary>
    [DataMember(Name="setSaleDateDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "setSaleDateDetails")]
    public SetSaleDateDetails SetSaleDateDetails { get; set; }

    /// <summary>
    /// Gets or Sets SaleHistory
    /// </summary>
    [DataMember(Name="saleHistory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "saleHistory")]
    public List<SaleHistory> SaleHistory { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CommercialSalePropertyExtended {\n");
      sb.Append("  AuctionDetails: ").Append(AuctionDetails).Append("\n");
      sb.Append("  TenderDetails: ").Append(TenderDetails).Append("\n");
      sb.Append("  SetSaleDateDetails: ").Append(SetSaleDateDetails).Append("\n");
      sb.Append("  SaleHistory: ").Append(SaleHistory).Append("\n");
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
