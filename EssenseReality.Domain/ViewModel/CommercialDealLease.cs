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
  public class CommercialDealLease : CommercialDeal {
    /// <summary>
    /// Gets or Sets LeaseStart
    /// </summary>
    [DataMember(Name="leaseStart", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "leaseStart")]
    public DateTime? LeaseStart { get; set; }

    /// <summary>
    /// Gets or Sets LeaseExpiry
    /// </summary>
    [DataMember(Name="leaseExpiry", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "leaseExpiry")]
    public DateTime? LeaseExpiry { get; set; }

    /// <summary>
    /// Gets or Sets LeaseExpiryReminder
    /// </summary>
    [DataMember(Name="leaseExpiryReminder", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "leaseExpiryReminder")]
    public DateTime? LeaseExpiryReminder { get; set; }

    /// <summary>
    /// Gets or Sets LeaseExpiryReminderUser
    /// </summary>
    [DataMember(Name="leaseExpiryReminderUser", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "leaseExpiryReminderUser")]
    public Access LeaseExpiryReminderUser { get; set; }

    /// <summary>
    /// Gets or Sets AnnualRent
    /// </summary>
    [DataMember(Name="annualRent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "annualRent")]
    public float? AnnualRent { get; set; }

    /// <summary>
    /// Gets or Sets InitialTermYears
    /// </summary>
    [DataMember(Name="initialTermYears", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "initialTermYears")]
    public long? InitialTermYears { get; set; }

    /// <summary>
    /// Gets or Sets Renewal1Years
    /// </summary>
    [DataMember(Name="renewal1Years", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "renewal1Years")]
    public long? Renewal1Years { get; set; }

    /// <summary>
    /// Gets or Sets Renewal2Years
    /// </summary>
    [DataMember(Name="renewal2Years", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "renewal2Years")]
    public long? Renewal2Years { get; set; }

    /// <summary>
    /// Gets or Sets Renewal3Years
    /// </summary>
    [DataMember(Name="renewal3Years", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "renewal3Years")]
    public long? Renewal3Years { get; set; }

    /// <summary>
    /// Gets or Sets FitoutEstimate
    /// </summary>
    [DataMember(Name="fitoutEstimate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fitoutEstimate")]
    public float? FitoutEstimate { get; set; }

    /// <summary>
    /// Gets or Sets OtherIncentives
    /// </summary>
    [DataMember(Name="otherIncentives", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "otherIncentives")]
    public string OtherIncentives { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CommercialDealLease {\n");
      sb.Append("  LeaseStart: ").Append(LeaseStart).Append("\n");
      sb.Append("  LeaseExpiry: ").Append(LeaseExpiry).Append("\n");
      sb.Append("  LeaseExpiryReminder: ").Append(LeaseExpiryReminder).Append("\n");
      sb.Append("  LeaseExpiryReminderUser: ").Append(LeaseExpiryReminderUser).Append("\n");
      sb.Append("  AnnualRent: ").Append(AnnualRent).Append("\n");
      sb.Append("  InitialTermYears: ").Append(InitialTermYears).Append("\n");
      sb.Append("  Renewal1Years: ").Append(Renewal1Years).Append("\n");
      sb.Append("  Renewal2Years: ").Append(Renewal2Years).Append("\n");
      sb.Append("  Renewal3Years: ").Append(Renewal3Years).Append("\n");
      sb.Append("  FitoutEstimate: ").Append(FitoutEstimate).Append("\n");
      sb.Append("  OtherIncentives: ").Append(OtherIncentives).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public  new string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
