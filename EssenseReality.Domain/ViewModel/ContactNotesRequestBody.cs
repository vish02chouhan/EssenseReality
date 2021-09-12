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
  public class ContactNotesRequestBody {
    /// <summary>
    /// Gets or Sets ModifiedSince
    /// </summary>
    [DataMember(Name="modifiedSince", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modifiedSince")]
    public DateTime? ModifiedSince { get; set; }

    /// <summary>
    /// Gets or Sets ModifiedBefore
    /// </summary>
    [DataMember(Name="modifiedBefore", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modifiedBefore")]
    public DateTime? ModifiedBefore { get; set; }

    /// <summary>
    /// Gets or Sets InsertedSince
    /// </summary>
    [DataMember(Name="insertedSince", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "insertedSince")]
    public DateTime? InsertedSince { get; set; }

    /// <summary>
    /// Gets or Sets InsertedBefore
    /// </summary>
    [DataMember(Name="insertedBefore", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "insertedBefore")]
    public DateTime? InsertedBefore { get; set; }

    /// <summary>
    /// Gets or Sets Types
    /// </summary>
    [DataMember(Name="types", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "types")]
    public List<long?> Types { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ContactNotesRequestBody {\n");
      sb.Append("  ModifiedSince: ").Append(ModifiedSince).Append("\n");
      sb.Append("  ModifiedBefore: ").Append(ModifiedBefore).Append("\n");
      sb.Append("  InsertedSince: ").Append(InsertedSince).Append("\n");
      sb.Append("  InsertedBefore: ").Append(InsertedBefore).Append("\n");
      sb.Append("  Types: ").Append(Types).Append("\n");
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
