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
  public class AuctionDetails {
    /// <summary>
    /// Gets or Sets DateTime
    /// </summary>
    [DataMember(Name="dateTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dateTime")]
    public DateTime? DateTime { get; set; }

    /// <summary>
    /// Gets or Sets Venue
    /// </summary>
    [DataMember(Name="venue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "venue")]
    public string Venue { get; set; }

    /// <summary>
    /// Gets or Sets Auctioneer
    /// </summary>
    [DataMember(Name="auctioneer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "auctioneer")]
    public string Auctioneer { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AuctionDetails {\n");
      sb.Append("  DateTime: ").Append(DateTime).Append("\n");
      sb.Append("  Venue: ").Append(Venue).Append("\n");
      sb.Append("  Auctioneer: ").Append(Auctioneer).Append("\n");
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
