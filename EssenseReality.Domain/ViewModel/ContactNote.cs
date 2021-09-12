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
  public class ContactNote {
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
    /// Gets or Sets Modified
    /// </summary>
    [DataMember(Name="modified", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modified")]
    public DateTime? Modified { get; set; }

    /// <summary>
    /// Gets or Sets Body
    /// </summary>
    [DataMember(Name="body", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "body")]
    public string Body { get; set; }

    /// <summary>
    /// Gets or Sets _ReadOnly
    /// </summary>
    [DataMember(Name="readOnly", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "readOnly")]
    public bool? _ReadOnly { get; set; }

    /// <summary>
    /// Gets or Sets Contact
    /// </summary>
    [DataMember(Name="contact", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contact")]
    public ID Contact { get; set; }

    /// <summary>
    /// Gets or Sets InsertedBy
    /// </summary>
    [DataMember(Name="insertedBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "insertedBy")]
    public User InsertedBy { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public ContactNoteType Type { get; set; }

    /// <summary>
    /// Gets or Sets Reminder
    /// </summary>
    [DataMember(Name="reminder", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reminder")]
    public ContactNoteReminder Reminder { get; set; }

    /// <summary>
    /// Gets or Sets PropertyFeedback
    /// </summary>
    [DataMember(Name="propertyFeedback", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "propertyFeedback")]
    public PropertyFeedback PropertyFeedback { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ContactNote {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Modified: ").Append(Modified).Append("\n");
      sb.Append("  Body: ").Append(Body).Append("\n");
      sb.Append("  _ReadOnly: ").Append(_ReadOnly).Append("\n");
      sb.Append("  Contact: ").Append(Contact).Append("\n");
      sb.Append("  InsertedBy: ").Append(InsertedBy).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Reminder: ").Append(Reminder).Append("\n");
      sb.Append("  PropertyFeedback: ").Append(PropertyFeedback).Append("\n");
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
