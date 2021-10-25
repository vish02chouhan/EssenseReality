using System;
using System.Collections.Generic;

namespace EssenceRealty.Domain.ViewModels
{
    public class PropertyViewModel
    {
        public int Id { get; set; }
        public string DisplayAddress { get; set; }
        public int Bath { get; set; }
        public int Bed { get; set; }
        public int Carports { get; set; }// Assuming this is parking space
        public long FloorAreaValue { get; set; }
        public string FloorAreaUnit { get; set; }
        public float SearchPrice { get; set; }
        public float DisplayPrice { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? YearBuilt { get; set; }
        public int Stories { get; set; }
        public long? ReceptionRooms { get; set; }
        public string VolumeNumber { get; set; }
        public FloorPlanViewModel FloorPlan { get; set; }
        public PropertyTypeViewModel PropertyType { get; set; }
        public ICollection<PhotoViewModel> Photo { get; set; }
        public ICollection<ContactStaffViewModel> ContactStaff { get; set; }
        public List<PropertyFeatureGroupingViewModel> PropertyFeatureGrouping { get; set; }
        public string Level { get; set; }
        public string UnitNumber { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public CountryViewModel Country { get; set; }
        public SuburbViewModel Suburb { get; set; }
        public string Accuracy { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}