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
  public class Account {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets BusinessName
    /// </summary>
    [DataMember(Name="businessName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "businessName")]
    public string BusinessName { get; set; }

    /// <summary>
    /// Gets or Sets EMarketingName
    /// </summary>
    [DataMember(Name="eMarketingName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "eMarketingName")]
    public string EMarketingName { get; set; }

    /// <summary>
    /// Gets or Sets Timezone
    /// </summary>
    [DataMember(Name="timezone", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "timezone")]
    public string Timezone { get; set; }

    /// <summary>
    /// Gets or Sets OpenDatabase
    /// </summary>
    [DataMember(Name="openDatabase", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "openDatabase")]
    public bool? OpenDatabase { get; set; }

    /// <summary>
    /// Gets or Sets Email
    /// </summary>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or Sets PhoneNumbers
    /// </summary>
    [DataMember(Name="phoneNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phoneNumbers")]
    public List<PhoneNumber> PhoneNumbers { get; set; }

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
    /// Gets or Sets Franchise
    /// </summary>
    [DataMember(Name="franchise", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "franchise")]
    public AccountFranchise Franchise { get; set; }

    /// <summary>
    /// Gets or Sets Speciality
    /// </summary>
    [DataMember(Name="speciality", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "speciality")]
    public string Speciality { get; set; }

    /// <summary>
    /// Gets or Sets MarketingUserOrders
    /// </summary>
    [DataMember(Name="marketingUserOrders", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "marketingUserOrders")]
    public List<MarketingUserOrder> MarketingUserOrders { get; set; }

    /// <summary>
    /// Gets or Sets WebsiteUrl
    /// </summary>
    [DataMember(Name="websiteUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "websiteUrl")]
    public string WebsiteUrl { get; set; }

    /// <summary>
    /// Gets or Sets ClientLoginUrl
    /// </summary>
    [DataMember(Name="clientLoginUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "clientLoginUrl")]
    public string ClientLoginUrl { get; set; }

    /// <summary>
    /// Gets or Sets OpeningHours
    /// </summary>
    [DataMember(Name="openingHours", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "openingHours")]
    public AccountOpeningHours OpeningHours { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Account {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  BusinessName: ").Append(BusinessName).Append("\n");
      sb.Append("  EMarketingName: ").Append(EMarketingName).Append("\n");
      sb.Append("  Timezone: ").Append(Timezone).Append("\n");
      sb.Append("  OpenDatabase: ").Append(OpenDatabase).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  PhoneNumbers: ").Append(PhoneNumbers).Append("\n");
      sb.Append("  Address: ").Append(Address).Append("\n");
      sb.Append("  PostalAddress: ").Append(PostalAddress).Append("\n");
      sb.Append("  Franchise: ").Append(Franchise).Append("\n");
      sb.Append("  Speciality: ").Append(Speciality).Append("\n");
      sb.Append("  MarketingUserOrders: ").Append(MarketingUserOrders).Append("\n");
      sb.Append("  WebsiteUrl: ").Append(WebsiteUrl).Append("\n");
      sb.Append("  ClientLoginUrl: ").Append(ClientLoginUrl).Append("\n");
      sb.Append("  OpeningHours: ").Append(OpeningHours).Append("\n");
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
