﻿using System;
using System.Collections.Generic;

namespace EssenseReality.Domain.Models
{
    public class Property : WhoFields
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
        public Geolocation Geolocation { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }//Need to check as per html need to show "Fo Sale" etc
        public PropertyType PropertyType { get; set; }
        public int? YearBuilt { get; set; }

        // public int Stories { get; set; } // Not able to find this attribute/ data points in CRM
        public long? ReceptionRooms { get; set; } // Assuming it will give room count
        public List<PropertyFeature> PropertyFeature { get;set; }
        public Address Address { get; set; }
        public List<Photo> Photos { get; set; }
        public List<ContactStaff> ContactStaff { get; set; }
        public string VolumeNumber { get; set; }


        //public object LandValue { get; set; }
        //public string TenantName { get; set; }
        //public string PortalStatus { get; set; }
        //public object Branch { get; set; }
        //public object AuthorityStart { get; set; }
        //public DateTime Inserted { get; set; }
        //public string BrochureDescription { get; set; }
        //public object RoyalMailId { get; set; }
        //public object TenureOrTitleType { get; set; }
        //public Class Class { get; set; }
        //public string TenantEmail { get; set; }
        //public string CommercialListingType { get; set; }
        //public bool Tenanted { get; set; }
        //public AuctionDetails AuctionDetails { get; set; }
        //public string Heading { get; set; }
        //public MethodOfSale MethodOfSale { get; set; }
        //public TenderDetails TenderDetails { get; set; }
        //public FloorArea FloorArea { get; set; }
        //public object EnergyRating { get; set; }
        //public object ETableUrl { get; set; }
        //public int? Ensuites { get; set; }
        //public string ReferenceID { get; set; }
        //public object TenancyStart { get; set; }
        //public object EpcGraphUrl { get; set; }
        //public object Building { get; set; } 
        //public string AddressVisibility { get; set; }
        //public LandArea LandArea { get; set; }
        //public string LotNumber { get; set; }
        //public SetSaleDateDetails SetSaleDateDetails { get; set; }
        //public int OpenSpaces { get; set; }
        //public DateTime Modified { get; set; }
        //public int SaleLifeId { get; set; }      
        //public object SellingFeePercent { get; set; }
        //public bool PriceOnApplication { get; set; }
        //public object PublishedToWeb { get; set; }
        //public List<object> ExternalLinks { get; set; }
        //public object PriceQualifier { get; set; }
        //public string MobileMarketingDescription { get; set; }
        //public int? Toilets { get; set; }
        //public double? Vpa { get; set; }
        //public string TenantPhone { get; set; }
        //public string TenancyDetails { get; set; }
        //public object WebId { get; set; }
        //public object SellingFeeFixed { get; set; }
        //public int LeaseLifeId { get; set; }
        //public double? Frontage { get; set; }
        //public string LegalDescription { get; set; }
        //public object TenancyStop { get; set; }
        //public string FolioNumber { get; set; }
        //public int CorelogicId { get; set; }
        //public int Garages { get; set; }
        //public object ImprovementValue { get; set; }
        //public string Rpdp { get; set; }
        //public AuthorityType AuthorityType { get; set; }
        //public Rates Rates { get; set; }
        //public object RateableValue { get; set; }
    }


}