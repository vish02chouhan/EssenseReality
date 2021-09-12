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
  public class PropertyLife : ResidentialProperty {
    /// <summary>
    /// Gets or Sets Zoning
    /// </summary>
    [DataMember(Name="zoning", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "zoning")]
    public string Zoning { get; set; }

    /// <summary>
    /// Gets or Sets CarSpaces
    /// </summary>
    [DataMember(Name="carSpaces", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carSpaces")]
    public long? CarSpaces { get; set; }

    /// <summary>
    /// Gets or Sets FloorArea
    /// </summary>
    [DataMember(Name="floorArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "floorArea")]
    public Area FloorArea { get; set; }

    /// <summary>
    /// Gets or Sets MezzanineArea
    /// </summary>
    [DataMember(Name="mezzanineArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mezzanineArea")]
    public Area MezzanineArea { get; set; }

    /// <summary>
    /// Gets or Sets WarehouseArea
    /// </summary>
    [DataMember(Name="warehouseArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "warehouseArea")]
    public Area WarehouseArea { get; set; }

    /// <summary>
    /// Gets or Sets RetailArea
    /// </summary>
    [DataMember(Name="retailArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "retailArea")]
    public Area RetailArea { get; set; }

    /// <summary>
    /// Gets or Sets OfficeArea
    /// </summary>
    [DataMember(Name="officeArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "officeArea")]
    public Area OfficeArea { get; set; }

    /// <summary>
    /// Gets or Sets OtherArea
    /// </summary>
    [DataMember(Name="otherArea", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "otherArea")]
    public Area OtherArea { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or Sets PortalStatus
    /// </summary>
    [DataMember(Name="portalStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "portalStatus")]
    public string PortalStatus { get; set; }

    /// <summary>
    /// Gets or Sets ContactStaff
    /// </summary>
    [DataMember(Name="contactStaff", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contactStaff")]
    public List<ID> ContactStaff { get; set; }

    /// <summary>
    /// Gets or Sets ETableUrl
    /// </summary>
    [DataMember(Name="eTableUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "eTableUrl")]
    public string ETableUrl { get; set; }

    /// <summary>
    /// Gets or Sets CommercialListingType
    /// </summary>
    [DataMember(Name="commercialListingType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "commercialListingType")]
    public string CommercialListingType { get; set; }

    /// <summary>
    /// Gets or Sets ExternalLinks
    /// </summary>
    [DataMember(Name="externalLinks", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "externalLinks")]
    public List<ExternalLink> ExternalLinks { get; set; }

    /// <summary>
    /// Gets or Sets EnergyRating
    /// </summary>
    [DataMember(Name="energyRating", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "energyRating")]
    public float? EnergyRating { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PropertyLife {\n");
      sb.Append("  Zoning: ").Append(Zoning).Append("\n");
      sb.Append("  CarSpaces: ").Append(CarSpaces).Append("\n");
      sb.Append("  FloorArea: ").Append(FloorArea).Append("\n");
      sb.Append("  MezzanineArea: ").Append(MezzanineArea).Append("\n");
      sb.Append("  WarehouseArea: ").Append(WarehouseArea).Append("\n");
      sb.Append("  RetailArea: ").Append(RetailArea).Append("\n");
      sb.Append("  OfficeArea: ").Append(OfficeArea).Append("\n");
      sb.Append("  OtherArea: ").Append(OtherArea).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  PortalStatus: ").Append(PortalStatus).Append("\n");
      sb.Append("  ContactStaff: ").Append(ContactStaff).Append("\n");
      sb.Append("  ETableUrl: ").Append(ETableUrl).Append("\n");
      sb.Append("  CommercialListingType: ").Append(CommercialListingType).Append("\n");
      sb.Append("  ExternalLinks: ").Append(ExternalLinks).Append("\n");
      sb.Append("  EnergyRating: ").Append(EnergyRating).Append("\n");
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
