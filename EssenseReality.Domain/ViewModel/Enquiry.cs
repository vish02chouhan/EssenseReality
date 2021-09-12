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
  public class Enquiry {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public decimal? Id { get; set; }

    /// <summary>
    /// Gets or Sets Subject
    /// </summary>
    [DataMember(Name="subject", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "subject")]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or Sets OriginalId
    /// </summary>
    [DataMember(Name="originalId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "originalId")]
    public string OriginalId { get; set; }

    /// <summary>
    /// Gets or Sets Inserted
    /// </summary>
    [DataMember(Name="inserted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "inserted")]
    public DateTime? Inserted { get; set; }

    /// <summary>
    /// Gets or Sets Source
    /// </summary>
    [DataMember(Name="source", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "source")]
    public string Source { get; set; }

    /// <summary>
    /// Gets or Sets SourceName
    /// </summary>
    [DataMember(Name="sourceName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sourceName")]
    public string SourceName { get; set; }

    /// <summary>
    /// Gets or Sets SaleLifeId
    /// </summary>
    [DataMember(Name="saleLifeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "saleLifeId")]
    public decimal? SaleLifeId { get; set; }

    /// <summary>
    /// Gets or Sets LeaseLifeId
    /// </summary>
    [DataMember(Name="leaseLifeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "leaseLifeId")]
    public decimal? LeaseLifeId { get; set; }

    /// <summary>
    /// Gets or Sets Processed
    /// </summary>
    [DataMember(Name="processed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "processed")]
    public bool? Processed { get; set; }

    /// <summary>
    /// Gets or Sets EnquiryDate
    /// </summary>
    [DataMember(Name="enquiryDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "enquiryDate")]
    public DateTime? EnquiryDate { get; set; }

    /// <summary>
    /// Gets or Sets Body
    /// </summary>
    [DataMember(Name="body", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "body")]
    public string Body { get; set; }

    /// <summary>
    /// Gets or Sets ContactId
    /// </summary>
    [DataMember(Name="contactId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contactId")]
    public decimal? ContactId { get; set; }

    /// <summary>
    /// Gets or Sets PersonEmails
    /// </summary>
    [DataMember(Name="personEmails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "personEmails")]
    public List<string> PersonEmails { get; set; }

    /// <summary>
    /// Gets or Sets PersonName
    /// </summary>
    [DataMember(Name="personName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "personName")]
    public string PersonName { get; set; }

    /// <summary>
    /// Gets or Sets Unsubscribe
    /// </summary>
    [DataMember(Name="unsubscribe", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unsubscribe")]
    public EnquiryUnsubscribe Unsubscribe { get; set; }

    /// <summary>
    /// Gets or Sets PersonPhoneNumbers
    /// </summary>
    [DataMember(Name="personPhoneNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "personPhoneNumbers")]
    public List<PhoneNumber> PersonPhoneNumbers { get; set; }

    /// <summary>
    /// Gets or Sets Categories
    /// </summary>
    [DataMember(Name="categories", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "categories")]
    public List<Category> Categories { get; set; }

    /// <summary>
    /// Gets or Sets User
    /// </summary>
    [DataMember(Name="user", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "user")]
    public Access User { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Enquiry {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Subject: ").Append(Subject).Append("\n");
      sb.Append("  OriginalId: ").Append(OriginalId).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Source: ").Append(Source).Append("\n");
      sb.Append("  SourceName: ").Append(SourceName).Append("\n");
      sb.Append("  SaleLifeId: ").Append(SaleLifeId).Append("\n");
      sb.Append("  LeaseLifeId: ").Append(LeaseLifeId).Append("\n");
      sb.Append("  Processed: ").Append(Processed).Append("\n");
      sb.Append("  EnquiryDate: ").Append(EnquiryDate).Append("\n");
      sb.Append("  Body: ").Append(Body).Append("\n");
      sb.Append("  ContactId: ").Append(ContactId).Append("\n");
      sb.Append("  PersonEmails: ").Append(PersonEmails).Append("\n");
      sb.Append("  PersonName: ").Append(PersonName).Append("\n");
      sb.Append("  Unsubscribe: ").Append(Unsubscribe).Append("\n");
      sb.Append("  PersonPhoneNumbers: ").Append(PersonPhoneNumbers).Append("\n");
      sb.Append("  Categories: ").Append(Categories).Append("\n");
      sb.Append("  User: ").Append(User).Append("\n");
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
