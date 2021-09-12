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
  public class AddEnquiry {
    /// <summary>
    /// Gets or Sets EnquiryDate
    /// </summary>
    [DataMember(Name="enquiryDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "enquiryDate")]
    public DateTime? EnquiryDate { get; set; }

    /// <summary>
    /// Gets or Sets Subject
    /// </summary>
    [DataMember(Name="subject", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "subject")]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or Sets Body
    /// </summary>
    [DataMember(Name="body", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "body")]
    public string Body { get; set; }

    /// <summary>
    /// Gets or Sets OriginalId
    /// </summary>
    [DataMember(Name="originalId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "originalId")]
    public string OriginalId { get; set; }

    /// <summary>
    /// Gets or Sets PropertyReference
    /// </summary>
    [DataMember(Name="propertyReference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "propertyReference")]
    public string PropertyReference { get; set; }

    /// <summary>
    /// Gets or Sets Source
    /// </summary>
    [DataMember(Name="source", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "source")]
    public string Source { get; set; }

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
    /// Gets or Sets UserId
    /// </summary>
    [DataMember(Name="userId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userId")]
    public decimal? UserId { get; set; }

    /// <summary>
    /// Gets or Sets FullName
    /// </summary>
    [DataMember(Name="fullName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fullName")]
    public string FullName { get; set; }

    /// <summary>
    /// Gets or Sets FirstName
    /// </summary>
    [DataMember(Name="firstName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "firstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or Sets LastName
    /// </summary>
    [DataMember(Name="lastName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or Sets Email
    /// </summary>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or Sets Telephone
    /// </summary>
    [DataMember(Name="telephone", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "telephone")]
    public string Telephone { get; set; }

    /// <summary>
    /// Gets or Sets Mobile
    /// </summary>
    [DataMember(Name="mobile", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mobile")]
    public string Mobile { get; set; }

    /// <summary>
    /// Gets or Sets Categories
    /// </summary>
    [DataMember(Name="categories", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "categories")]
    public List<ID> Categories { get; set; }

    /// <summary>
    /// Gets or Sets MetaData
    /// </summary>
    [DataMember(Name="metaData", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "metaData")]
    public List<AddEnquiryMetaData> MetaData { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddEnquiry {\n");
      sb.Append("  EnquiryDate: ").Append(EnquiryDate).Append("\n");
      sb.Append("  Subject: ").Append(Subject).Append("\n");
      sb.Append("  Body: ").Append(Body).Append("\n");
      sb.Append("  OriginalId: ").Append(OriginalId).Append("\n");
      sb.Append("  PropertyReference: ").Append(PropertyReference).Append("\n");
      sb.Append("  Source: ").Append(Source).Append("\n");
      sb.Append("  SaleLifeId: ").Append(SaleLifeId).Append("\n");
      sb.Append("  LeaseLifeId: ").Append(LeaseLifeId).Append("\n");
      sb.Append("  UserId: ").Append(UserId).Append("\n");
      sb.Append("  FullName: ").Append(FullName).Append("\n");
      sb.Append("  FirstName: ").Append(FirstName).Append("\n");
      sb.Append("  LastName: ").Append(LastName).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  Telephone: ").Append(Telephone).Append("\n");
      sb.Append("  Mobile: ").Append(Mobile).Append("\n");
      sb.Append("  Categories: ").Append(Categories).Append("\n");
      sb.Append("  MetaData: ").Append(MetaData).Append("\n");
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
