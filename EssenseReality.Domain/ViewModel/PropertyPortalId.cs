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
  public class PropertyPortalId {
    /// <summary>
    /// Gets or Sets PortalId
    /// </summary>
    [DataMember(Name="portalId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "portalId")]
    public string PortalId { get; set; }

    /// <summary>
    /// Gets or Sets OfficePortal
    /// </summary>
    [DataMember(Name="officePortal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "officePortal")]
    public PortalAccess OfficePortal { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PropertyPortalId {\n");
      sb.Append("  PortalId: ").Append(PortalId).Append("\n");
      sb.Append("  OfficePortal: ").Append(OfficePortal).Append("\n");
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
