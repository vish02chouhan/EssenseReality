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
  public class MaintenanceRequest {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets Inserted
    /// </summary>
    [DataMember(Name="inserted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "inserted")]
    public DateTime? Inserted { get; set; }

    /// <summary>
    /// Gets or Sets Supplier
    /// </summary>
    [DataMember(Name="supplier", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "supplier")]
    public ContactMinimal Supplier { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or Sets JobId
    /// </summary>
    [DataMember(Name="jobId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "jobId")]
    public long? JobId { get; set; }

    /// <summary>
    /// Gets or Sets Quote
    /// </summary>
    [DataMember(Name="quote", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "quote")]
    public PropertyFile Quote { get; set; }

    /// <summary>
    /// Gets or Sets Invoice
    /// </summary>
    [DataMember(Name="invoice", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "invoice")]
    public PropertyFile Invoice { get; set; }

    /// <summary>
    /// Gets or Sets IsWorkOrder
    /// </summary>
    [DataMember(Name="isWorkOrder", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isWorkOrder")]
    public bool? IsWorkOrder { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MaintenanceRequest {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Supplier: ").Append(Supplier).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  JobId: ").Append(JobId).Append("\n");
      sb.Append("  Quote: ").Append(Quote).Append("\n");
      sb.Append("  Invoice: ").Append(Invoice).Append("\n");
      sb.Append("  IsWorkOrder: ").Append(IsWorkOrder).Append("\n");
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
