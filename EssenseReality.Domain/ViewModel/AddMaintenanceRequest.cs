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
  public class AddMaintenanceRequest {
    /// <summary>
    /// Gets or Sets Supplier
    /// </summary>
    [DataMember(Name="supplier", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "supplier")]
    public ID Supplier { get; set; }

    /// <summary>
    /// Gets or Sets Subject
    /// </summary>
    [DataMember(Name="subject", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "subject")]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or Sets BodyHTML
    /// </summary>
    [DataMember(Name="bodyHTML", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bodyHTML")]
    public string BodyHTML { get; set; }

    /// <summary>
    /// Gets or Sets IsWorkOrder
    /// </summary>
    [DataMember(Name="isWorkOrder", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isWorkOrder")]
    public bool? IsWorkOrder { get; set; }

    /// <summary>
    /// Gets or Sets Sender
    /// </summary>
    [DataMember(Name="sender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sender")]
    public ID Sender { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddMaintenanceRequest {\n");
      sb.Append("  Supplier: ").Append(Supplier).Append("\n");
      sb.Append("  Subject: ").Append(Subject).Append("\n");
      sb.Append("  BodyHTML: ").Append(BodyHTML).Append("\n");
      sb.Append("  IsWorkOrder: ").Append(IsWorkOrder).Append("\n");
      sb.Append("  Sender: ").Append(Sender).Append("\n");
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
