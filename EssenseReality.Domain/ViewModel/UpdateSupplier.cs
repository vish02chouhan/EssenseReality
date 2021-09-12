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
  public class UpdateSupplier {
    /// <summary>
    /// Gets or Sets Title
    /// </summary>
    [DataMember(Name="title", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

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
    /// Gets or Sets Greeting
    /// </summary>
    [DataMember(Name="greeting", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "greeting")]
    public string Greeting { get; set; }

    /// <summary>
    /// Gets or Sets PartnerTitle
    /// </summary>
    [DataMember(Name="partnerTitle", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "partnerTitle")]
    public string PartnerTitle { get; set; }

    /// <summary>
    /// Gets or Sets PartnerFirstName
    /// </summary>
    [DataMember(Name="partnerFirstName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "partnerFirstName")]
    public string PartnerFirstName { get; set; }

    /// <summary>
    /// Gets or Sets PartnerLastName
    /// </summary>
    [DataMember(Name="partnerLastName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "partnerLastName")]
    public string PartnerLastName { get; set; }

    /// <summary>
    /// Gets or Sets Company
    /// </summary>
    [DataMember(Name="company", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "company")]
    public string Company { get; set; }

    /// <summary>
    /// Gets or Sets Position
    /// </summary>
    [DataMember(Name="position", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "position")]
    public string Position { get; set; }

    /// <summary>
    /// Gets or Sets Address
    /// </summary>
    [DataMember(Name="address", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "address")]
    public UpdateAddress Address { get; set; }

    /// <summary>
    /// Gets or Sets PostalAddress
    /// </summary>
    [DataMember(Name="postalAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postalAddress")]
    public UpdateAddress PostalAddress { get; set; }

    /// <summary>
    /// Gets or Sets OnDoNotCallList
    /// </summary>
    [DataMember(Name="onDoNotCallList", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "onDoNotCallList")]
    public bool? OnDoNotCallList { get; set; }

    /// <summary>
    /// Gets or Sets Unsubscribe
    /// </summary>
    [DataMember(Name="unsubscribe", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unsubscribe")]
    public Unsubscribe Unsubscribe { get; set; }

    /// <summary>
    /// Gets or Sets Emails
    /// </summary>
    [DataMember(Name="emails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "emails")]
    public List<string> Emails { get; set; }

    /// <summary>
    /// Gets or Sets PhoneNumbers
    /// </summary>
    [DataMember(Name="phoneNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phoneNumbers")]
    public List<PhoneNumber> PhoneNumbers { get; set; }

    /// <summary>
    /// Gets or Sets LegalDescription
    /// </summary>
    [DataMember(Name="legalDescription", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "legalDescription")]
    public string LegalDescription { get; set; }

    /// <summary>
    /// Gets or Sets AccessBy
    /// </summary>
    [DataMember(Name="accessBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessBy")]
    public List<ID> AccessBy { get; set; }

    /// <summary>
    /// Gets or Sets SourceOfEnquiry
    /// </summary>
    [DataMember(Name="sourceOfEnquiry", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sourceOfEnquiry")]
    public ID SourceOfEnquiry { get; set; }

    /// <summary>
    /// Gets or Sets MarketingUsers
    /// </summary>
    [DataMember(Name="marketingUsers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "marketingUsers")]
    public List<AddUpdateMarketingUser> MarketingUsers { get; set; }

    /// <summary>
    /// Gets or Sets Labels
    /// </summary>
    [DataMember(Name="labels", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "labels")]
    public List<string> Labels { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateSupplier {\n");
      sb.Append("  Title: ").Append(Title).Append("\n");
      sb.Append("  FirstName: ").Append(FirstName).Append("\n");
      sb.Append("  LastName: ").Append(LastName).Append("\n");
      sb.Append("  Greeting: ").Append(Greeting).Append("\n");
      sb.Append("  PartnerTitle: ").Append(PartnerTitle).Append("\n");
      sb.Append("  PartnerFirstName: ").Append(PartnerFirstName).Append("\n");
      sb.Append("  PartnerLastName: ").Append(PartnerLastName).Append("\n");
      sb.Append("  Company: ").Append(Company).Append("\n");
      sb.Append("  Position: ").Append(Position).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
      sb.Append("  PostalAddress: ").Append(PostalAddress).Append("\n");
      sb.Append("  OnDoNotCallList: ").Append(OnDoNotCallList).Append("\n");
      sb.Append("  Unsubscribe: ").Append(Unsubscribe).Append("\n");
      sb.Append("  Emails: ").Append(Emails).Append("\n");
      sb.Append("  PhoneNumbers: ").Append(PhoneNumbers).Append("\n");
      sb.Append("  LegalDescription: ").Append(LegalDescription).Append("\n");
      sb.Append("  AccessBy: ").Append(AccessBy).Append("\n");
      sb.Append("  SourceOfEnquiry: ").Append(SourceOfEnquiry).Append("\n");
      sb.Append("  MarketingUsers: ").Append(MarketingUsers).Append("\n");
      sb.Append("  Labels: ").Append(Labels).Append("\n");
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
