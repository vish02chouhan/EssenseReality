using System;
using System.Collections.Generic;

namespace EssenseReality.Domain.Models
{
    public class Property : WhoFields, ICrmWhoFields, IAdminUpdate
    {
        public int Id { get; set; }
        public int CrmPropertyId { get; set; }
        public string DisplayAddress { get; set; }
        public int Bath { get; set; }
        public int Bed { get; set; }
        public int Carports { get; set; }// Assuming this is parking space
        public long FloorAreaValue { get; set; }
        public string FloorAreaUnit { get; set; }
        public float SearchPrice { get; set; }
        public float DisplayPrice { get; set; }
        public string Description { get; set; }
        //Need to check. In htm status has text as "For Sale", from api in status field getting value as appraisal
        public string Status { get; set; }
        public int? YearBuilt { get; set; }
        public int Stories { get; set; } // Not able to find this attribute/data points in CRM
        public long? ReceptionRooms { get; set; } // Assuming it will give room count
        public string VolumeNumber { get; set; }
        public FloorPlan FloorPlan { get; set; }
        public int SaleLifeId { get; set; }
        public int LeaseLifeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Inserted { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsAdminUpdated { get; set; }
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public ICollection<Photo> Photo { get; set; }
        public ICollection<ContactStaff> ContactStaff { get; set; }
        public List<PropertyFeature> PropertyFeature { get; set; }
        public string Level { get; set; }
        public string UnitNumber { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int SuburbId { get; set; }
        public Suburb Suburb { get; set; }
        public string Accuracy { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
