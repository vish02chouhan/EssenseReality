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
  public class Message {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public decimal? Id { get; set; }

    /// <summary>
    /// Gets or Sets ThreadId
    /// </summary>
    [DataMember(Name="threadId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "threadId")]
    public decimal? ThreadId { get; set; }

    /// <summary>
    /// Gets or Sets _Message
    /// </summary>
    [DataMember(Name="message", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "message")]
    public string _Message { get; set; }

    /// <summary>
    /// Gets or Sets Receipts
    /// </summary>
    [DataMember(Name="receipts", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "receipts")]
    public List<MessageReceipt> Receipts { get; set; }

    /// <summary>
    /// Gets or Sets InsertedBy
    /// </summary>
    [DataMember(Name="insertedBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "insertedBy")]
    public Access InsertedBy { get; set; }

    /// <summary>
    /// Gets or Sets Inserted
    /// </summary>
    [DataMember(Name="inserted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "inserted")]
    public DateTime? Inserted { get; set; }

    /// <summary>
    /// Gets or Sets IsFranchise
    /// </summary>
    [DataMember(Name="isFranchise", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isFranchise")]
    public bool? IsFranchise { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Message {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  ThreadId: ").Append(ThreadId).Append("\n");
      sb.Append("  _Message: ").Append(_Message).Append("\n");
      sb.Append("  Receipts: ").Append(Receipts).Append("\n");
      sb.Append("  InsertedBy: ").Append(InsertedBy).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  IsFranchise: ").Append(IsFranchise).Append("\n");
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
