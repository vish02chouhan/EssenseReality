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
  public class Maintenance {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets Summary
    /// </summary>
    [DataMember(Name="summary", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "summary")]
    public string Summary { get; set; }

    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or Sets Inserted
    /// </summary>
    [DataMember(Name="inserted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "inserted")]
    public DateTime? Inserted { get; set; }

    /// <summary>
    /// Gets or Sets Modified
    /// </summary>
    [DataMember(Name="modified", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modified")]
    public DateTime? Modified { get; set; }

    /// <summary>
    /// Gets or Sets InsertedBy
    /// </summary>
    [DataMember(Name="insertedBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "insertedBy")]
    public Access InsertedBy { get; set; }

    /// <summary>
    /// Gets or Sets RequestedBy
    /// </summary>
    [DataMember(Name="requestedBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "requestedBy")]
    public ContactMinimal RequestedBy { get; set; }

    /// <summary>
    /// Gets or Sets Tenancy
    /// </summary>
    [DataMember(Name="tenancy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenancy")]
    public Tenancy Tenancy { get; set; }

    /// <summary>
    /// Gets or Sets LeaseLifeId
    /// </summary>
    [DataMember(Name="leaseLifeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "leaseLifeId")]
    public long? LeaseLifeId { get; set; }

    /// <summary>
    /// Gets or Sets Photos
    /// </summary>
    [DataMember(Name="photos", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "photos")]
    public List<MaintenancePhoto> Photos { get; set; }

    /// <summary>
    /// Gets or Sets Notifications
    /// </summary>
    [DataMember(Name="notifications", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "notifications")]
    public List<Access> Notifications { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Maintenance {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Summary: ").Append(Summary).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Modified: ").Append(Modified).Append("\n");
      sb.Append("  InsertedBy: ").Append(InsertedBy).Append("\n");
      sb.Append("  RequestedBy: ").Append(RequestedBy).Append("\n");
      sb.Append("  Tenancy: ").Append(Tenancy).Append("\n");
      sb.Append("  LeaseLifeId: ").Append(LeaseLifeId).Append("\n");
      sb.Append("  Photos: ").Append(Photos).Append("\n");
      sb.Append("  Notifications: ").Append(Notifications).Append("\n");
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
