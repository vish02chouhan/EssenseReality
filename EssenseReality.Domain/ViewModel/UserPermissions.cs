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
  public class UserPermissions {
    /// <summary>
    /// Gets or Sets Settings
    /// </summary>
    [DataMember(Name="settings", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "settings")]
    public bool? Settings { get; set; }

    /// <summary>
    /// Gets or Sets AccessPropertyManagement
    /// </summary>
    [DataMember(Name="accessPropertyManagement", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessPropertyManagement")]
    public bool? AccessPropertyManagement { get; set; }

    /// <summary>
    /// Gets or Sets AccessSales
    /// </summary>
    [DataMember(Name="accessSales", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessSales")]
    public bool? AccessSales { get; set; }

    /// <summary>
    /// Gets or Sets CanLogin
    /// </summary>
    [DataMember(Name="canLogin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "canLogin")]
    public bool? CanLogin { get; set; }

    /// <summary>
    /// Gets or Sets DeleteContacts
    /// </summary>
    [DataMember(Name="deleteContacts", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "deleteContacts")]
    public bool? DeleteContacts { get; set; }

    /// <summary>
    /// Gets or Sets DeleteProperties
    /// </summary>
    [DataMember(Name="deleteProperties", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "deleteProperties")]
    public bool? DeleteProperties { get; set; }

    /// <summary>
    /// Gets or Sets GlobalActionListsReadWrite
    /// </summary>
    [DataMember(Name="globalActionListsReadWrite", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "globalActionListsReadWrite")]
    public bool? GlobalActionListsReadWrite { get; set; }

    /// <summary>
    /// Gets or Sets GlobalContactsReadWrite
    /// </summary>
    [DataMember(Name="globalContactsReadWrite", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "globalContactsReadWrite")]
    public bool? GlobalContactsReadWrite { get; set; }

    /// <summary>
    /// Gets or Sets GlobalNotesRead
    /// </summary>
    [DataMember(Name="globalNotesRead", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "globalNotesRead")]
    public bool? GlobalNotesRead { get; set; }

    /// <summary>
    /// Gets or Sets GlobalNotesReadWrite
    /// </summary>
    [DataMember(Name="globalNotesReadWrite", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "globalNotesReadWrite")]
    public bool? GlobalNotesReadWrite { get; set; }

    /// <summary>
    /// Gets or Sets GlobalPropertiesRead
    /// </summary>
    [DataMember(Name="globalPropertiesRead", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "globalPropertiesRead")]
    public bool? GlobalPropertiesRead { get; set; }

    /// <summary>
    /// Gets or Sets GlobalPropertiesReadWrite
    /// </summary>
    [DataMember(Name="globalPropertiesReadWrite", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "globalPropertiesReadWrite")]
    public bool? GlobalPropertiesReadWrite { get; set; }

    /// <summary>
    /// Gets or Sets GlobalTasksReadWrite
    /// </summary>
    [DataMember(Name="globalTasksReadWrite", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "globalTasksReadWrite")]
    public bool? GlobalTasksReadWrite { get; set; }

    /// <summary>
    /// Gets or Sets SendSMS
    /// </summary>
    [DataMember(Name="sendSMS", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sendSMS")]
    public bool? SendSMS { get; set; }

    /// <summary>
    /// Gets or Sets AccessPropertyFinancials
    /// </summary>
    [DataMember(Name="accessPropertyFinancials", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessPropertyFinancials")]
    public bool? AccessPropertyFinancials { get; set; }

    /// <summary>
    /// Gets or Sets AccessAlarmDetails
    /// </summary>
    [DataMember(Name="accessAlarmDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessAlarmDetails")]
    public bool? AccessAlarmDetails { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UserPermissions {\n");
      sb.Append("  Settings: ").Append(Settings).Append("\n");
      sb.Append("  AccessPropertyManagement: ").Append(AccessPropertyManagement).Append("\n");
      sb.Append("  AccessSales: ").Append(AccessSales).Append("\n");
      sb.Append("  CanLogin: ").Append(CanLogin).Append("\n");
      sb.Append("  DeleteContacts: ").Append(DeleteContacts).Append("\n");
      sb.Append("  DeleteProperties: ").Append(DeleteProperties).Append("\n");
      sb.Append("  GlobalActionListsReadWrite: ").Append(GlobalActionListsReadWrite).Append("\n");
      sb.Append("  GlobalContactsReadWrite: ").Append(GlobalContactsReadWrite).Append("\n");
      sb.Append("  GlobalNotesRead: ").Append(GlobalNotesRead).Append("\n");
      sb.Append("  GlobalNotesReadWrite: ").Append(GlobalNotesReadWrite).Append("\n");
      sb.Append("  GlobalPropertiesRead: ").Append(GlobalPropertiesRead).Append("\n");
      sb.Append("  GlobalPropertiesReadWrite: ").Append(GlobalPropertiesReadWrite).Append("\n");
      sb.Append("  GlobalTasksReadWrite: ").Append(GlobalTasksReadWrite).Append("\n");
      sb.Append("  SendSMS: ").Append(SendSMS).Append("\n");
      sb.Append("  AccessPropertyFinancials: ").Append(AccessPropertyFinancials).Append("\n");
      sb.Append("  AccessAlarmDetails: ").Append(AccessAlarmDetails).Append("\n");
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
