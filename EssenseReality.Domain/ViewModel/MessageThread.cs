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
  public class MessageThread {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public decimal? Id { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets Created
    /// </summary>
    [DataMember(Name="created", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "created")]
    public DateTime? Created { get; set; }

    /// <summary>
    /// Gets or Sets Modified
    /// </summary>
    [DataMember(Name="modified", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modified")]
    public DateTime? Modified { get; set; }

    /// <summary>
    /// Gets or Sets AccountId
    /// </summary>
    [DataMember(Name="accountId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accountId")]
    public decimal? AccountId { get; set; }

    /// <summary>
    /// Gets or Sets FranchiseId
    /// </summary>
    [DataMember(Name="franchiseId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "franchiseId")]
    public decimal? FranchiseId { get; set; }

    /// <summary>
    /// Gets or Sets InsertedBy
    /// </summary>
    [DataMember(Name="insertedBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "insertedBy")]
    public Access InsertedBy { get; set; }

    /// <summary>
    /// Gets or Sets Recipients
    /// </summary>
    [DataMember(Name="recipients", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "recipients")]
    public List<MessageRecipient> Recipients { get; set; }

    /// <summary>
    /// Gets or Sets LatestMessage
    /// </summary>
    [DataMember(Name="latestMessage", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "latestMessage")]
    public Message LatestMessage { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MessageThread {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Created: ").Append(Created).Append("\n");
      sb.Append("  Modified: ").Append(Modified).Append("\n");
      sb.Append("  AccountId: ").Append(AccountId).Append("\n");
      sb.Append("  FranchiseId: ").Append(FranchiseId).Append("\n");
      sb.Append("  InsertedBy: ").Append(InsertedBy).Append("\n");
      sb.Append("  Recipients: ").Append(Recipients).Append("\n");
      sb.Append("  LatestMessage: ").Append(LatestMessage).Append("\n");
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
