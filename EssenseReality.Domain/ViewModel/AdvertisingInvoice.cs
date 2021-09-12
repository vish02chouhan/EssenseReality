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
  public class AdvertisingInvoice {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public decimal? Id { get; set; }

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
    /// Gets or Sets InvoiceNumber
    /// </summary>
    [DataMember(Name="invoiceNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "invoiceNumber")]
    public decimal? InvoiceNumber { get; set; }

    /// <summary>
    /// Gets or Sets InsertedBy
    /// </summary>
    [DataMember(Name="insertedBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "insertedBy")]
    public Access InsertedBy { get; set; }

    /// <summary>
    /// Gets or Sets TotalAmount
    /// </summary>
    [DataMember(Name="totalAmount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalAmount")]
    public float? TotalAmount { get; set; }

    /// <summary>
    /// Gets or Sets AmountOutstanding
    /// </summary>
    [DataMember(Name="amountOutstanding", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "amountOutstanding")]
    public float? AmountOutstanding { get; set; }

    /// <summary>
    /// Gets or Sets AddressedTo
    /// </summary>
    [DataMember(Name="addressedTo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "addressedTo")]
    public ContactMinimal AddressedTo { get; set; }

    /// <summary>
    /// Gets or Sets GstRateUsed
    /// </summary>
    [DataMember(Name="gstRateUsed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gstRateUsed")]
    public float? GstRateUsed { get; set; }

    /// <summary>
    /// Gets or Sets UserInvoiced
    /// </summary>
    [DataMember(Name="userInvoiced", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userInvoiced")]
    public Access UserInvoiced { get; set; }

    /// <summary>
    /// Gets or Sets SaleLifeId
    /// </summary>
    [DataMember(Name="saleLifeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "saleLifeId")]
    public decimal? SaleLifeId { get; set; }

    /// <summary>
    /// Gets or Sets TenancyId
    /// </summary>
    [DataMember(Name="tenancyId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenancyId")]
    public decimal? TenancyId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AdvertisingInvoice {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Inserted: ").Append(Inserted).Append("\n");
      sb.Append("  Modified: ").Append(Modified).Append("\n");
      sb.Append("  InvoiceNumber: ").Append(InvoiceNumber).Append("\n");
      sb.Append("  InsertedBy: ").Append(InsertedBy).Append("\n");
      sb.Append("  TotalAmount: ").Append(TotalAmount).Append("\n");
      sb.Append("  AmountOutstanding: ").Append(AmountOutstanding).Append("\n");
      sb.Append("  AddressedTo: ").Append(AddressedTo).Append("\n");
      sb.Append("  GstRateUsed: ").Append(GstRateUsed).Append("\n");
      sb.Append("  UserInvoiced: ").Append(UserInvoiced).Append("\n");
      sb.Append("  SaleLifeId: ").Append(SaleLifeId).Append("\n");
      sb.Append("  TenancyId: ").Append(TenancyId).Append("\n");
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
