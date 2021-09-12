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
  public class Contact {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

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
    /// Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name="displayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "displayName")]
    public string DisplayName { get; set; }

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
    public Address Address { get; set; }

    /// <summary>
    /// Gets or Sets PostalAddress
    /// </summary>
    [DataMember(Name="postalAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postalAddress")]
    public Address PostalAddress { get; set; }

    /// <summary>
    /// Gets or Sets OnDoNotCallList
    /// </summary>
    [DataMember(Name="onDoNotCallList", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "onDoNotCallList")]
    public bool? OnDoNotCallList { get; set; }

    /// <summary>
    /// Gets or Sets Archived
    /// </summary>
    [DataMember(Name="archived", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "archived")]
    public bool? Archived { get; set; }

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
    /// Gets or Sets Touched
    /// </summary>
    [DataMember(Name="touched", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "touched")]
    public DateTime? Touched { get; set; }

    /// <summary>
    /// Gets or Sets RemoteId
    /// </summary>
    [DataMember(Name="remoteId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "remoteId")]
    public string RemoteId { get; set; }

    /// <summary>
    /// Gets or Sets Unsubscribe
    /// </summary>
    [DataMember(Name="unsubscribe", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "unsubscribe")]
    public Unsubscribe Unsubscribe { get; set; }

    /// <summary>
    /// Gets or Sets EntityType
    /// </summary>
    [DataMember(Name="entityType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "entityType")]
    public EntityType EntityType { get; set; }

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
    /// Gets or Sets MarketingUsers
    /// </summary>
    [DataMember(Name="marketingUsers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "marketingUsers")]
    public List<MarketingUser> MarketingUsers { get; set; }

    /// <summary>
    /// Gets or Sets SmsUnsubscribeUrl
    /// </summary>
    [DataMember(Name="smsUnsubscribeUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "smsUnsubscribeUrl")]
    public string SmsUnsubscribeUrl { get; set; }

    /// <summary>
    /// Gets or Sets CustomUnsubscribe
    /// </summary>
    [DataMember(Name="customUnsubscribe", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customUnsubscribe")]
    public List<UnsubscribeType> CustomUnsubscribe { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Contact {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Title: ").Append(Title).Append("\n");
      sb.Append("  FirstName: ").Append(FirstName).Append("\n");
      sb.Append("  LastName: ").Append(LastName).Append("\n");
      sb.Append("  Greeting: ").Append(Greeting).Append("\n");
      sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
      sb.Append("  PartnerTitle: ").Append(PartnerTitle).Append("\n");
      sb.Append("  PartnerFirstName: ").Append(PartnerFirstName).Append("\n");
      sb.Append("  PartnerLastName: ").Append(PartnerLastName).Append("\n");
      sb.Append("  Company: ").Append(Company).Append("\n");
      sb.Append("  Position: ").Append(Position).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
      sb.Append("  PostalAddress: ").Append(PostalAddress).Append("\n");
      sb.Append("  OnDoNotCallList: ").Append(OnDoNotCallList).Append("\n");
      sb.Append("  Archived: ").Append(Archived).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Modified: ").Append(Modified).Append("\n");
      sb.Append("  Touched: ").Append(Touched).Append("\n");
      sb.Append("  RemoteId: ").Append(RemoteId).Append("\n");
      sb.Append("  Unsubscribe: ").Append(Unsubscribe).Append("\n");
      sb.Append("  EntityType: ").Append(EntityType).Append("\n");
      sb.Append("  Emails: ").Append(Emails).Append("\n");
      sb.Append("  PhoneNumbers: ").Append(PhoneNumbers).Append("\n");
      sb.Append("  LegalDescription: ").Append(LegalDescription).Append("\n");
      sb.Append("  MarketingUsers: ").Append(MarketingUsers).Append("\n");
      sb.Append("  SmsUnsubscribeUrl: ").Append(SmsUnsubscribeUrl).Append("\n");
      sb.Append("  CustomUnsubscribe: ").Append(CustomUnsubscribe).Append("\n");
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
