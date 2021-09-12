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
  public class User {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

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
    /// Gets or Sets Username
    /// </summary>
    [DataMember(Name="username", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "username")]
    public string Username { get; set; }

    /// <summary>
    /// Gets or Sets Email
    /// </summary>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or Sets AdminAccess
    /// </summary>
    [DataMember(Name="adminAccess", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "adminAccess")]
    public bool? AdminAccess { get; set; }

    /// <summary>
    /// Gets or Sets Position
    /// </summary>
    [DataMember(Name="position", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "position")]
    public string Position { get; set; }

    /// <summary>
    /// Gets or Sets Role
    /// </summary>
    [DataMember(Name="role", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "role")]
    public string Role { get; set; }

    /// <summary>
    /// Gets or Sets Photo
    /// </summary>
    [DataMember(Name="photo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "photo")]
    public UserPhoto Photo { get; set; }

    /// <summary>
    /// Gets or Sets LastLogin
    /// </summary>
    [DataMember(Name="lastLogin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lastLogin")]
    public DateTime? LastLogin { get; set; }

    /// <summary>
    /// Gets or Sets PhoneNumbers
    /// </summary>
    [DataMember(Name="phoneNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "phoneNumbers")]
    public List<PhoneNumber> PhoneNumbers { get; set; }

    /// <summary>
    /// Gets or Sets Profile
    /// </summary>
    [DataMember(Name="profile", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "profile")]
    public string Profile { get; set; }

    /// <summary>
    /// Gets or Sets Permissions
    /// </summary>
    [DataMember(Name="permissions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "permissions")]
    public UserPermissions Permissions { get; set; }

    /// <summary>
    /// Gets or Sets WebsiteUrl
    /// </summary>
    [DataMember(Name="websiteUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "websiteUrl")]
    public string WebsiteUrl { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class User {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  FirstName: ").Append(FirstName).Append("\n");
      sb.Append("  LastName: ").Append(LastName).Append("\n");
      sb.Append("  Username: ").Append(Username).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  AdminAccess: ").Append(AdminAccess).Append("\n");
      sb.Append("  Position: ").Append(Position).Append("\n");
      sb.Append("  Role: ").Append(Role).Append("\n");
      sb.Append("  Photo: ").Append(Photo).Append("\n");
      sb.Append("  LastLogin: ").Append(LastLogin).Append("\n");
      sb.Append("  PhoneNumbers: ").Append(PhoneNumbers).Append("\n");
      sb.Append("  Profile: ").Append(Profile).Append("\n");
      sb.Append("  Permissions: ").Append(Permissions).Append("\n");
      sb.Append("  WebsiteUrl: ").Append(WebsiteUrl).Append("\n");
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
