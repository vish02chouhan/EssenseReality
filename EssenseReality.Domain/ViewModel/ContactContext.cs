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
  public class ContactContext {
    /// <summary>
    /// Gets or Sets PhoneNumbers
    /// </summary>
    [DataMember(Name="phoneNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phoneNumbers")]
    public List<PhoneNumber> PhoneNumbers { get; set; }

    /// <summary>
    /// Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name="displayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "displayName")]
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or Sets PartnerDisplayName
    /// </summary>
    [DataMember(Name="partnerDisplayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "partnerDisplayName")]
    public string PartnerDisplayName { get; set; }

    /// <summary>
    /// Gets or Sets CompanyInfo
    /// </summary>
    [DataMember(Name="companyInfo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "companyInfo")]
    public string CompanyInfo { get; set; }

    /// <summary>
    /// Gets or Sets Emails
    /// </summary>
    [DataMember(Name="emails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "emails")]
    public List<string> Emails { get; set; }

    /// <summary>
    /// Gets or Sets LinkedProperties
    /// </summary>
    [DataMember(Name="linkedProperties", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "linkedProperties")]
    public List<LinkedProperty> LinkedProperties { get; set; }

    /// <summary>
    /// Gets or Sets Categories
    /// </summary>
    [DataMember(Name="categories", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "categories")]
    public List<Category> Categories { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ContactContext {\n");
      sb.Append("  PhoneNumbers: ").Append(PhoneNumbers).Append("\n");
      sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
      sb.Append("  PartnerDisplayName: ").Append(PartnerDisplayName).Append("\n");
      sb.Append("  CompanyInfo: ").Append(CompanyInfo).Append("\n");
      sb.Append("  Emails: ").Append(Emails).Append("\n");
      sb.Append("  LinkedProperties: ").Append(LinkedProperties).Append("\n");
      sb.Append("  Categories: ").Append(Categories).Append("\n");
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
