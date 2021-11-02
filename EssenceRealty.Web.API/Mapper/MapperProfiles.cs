using EssenceRealty.Domain.Models;
using EssenceRealty.Domain.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace EssenceRealty.Web.API.Mapper
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<Property, PropertyViewModel>();
            CreateMap<Suburb, SuburbViewModel>();
            CreateMap<State, StateViewModel>();
            CreateMap<Country, CountryViewModel>();
            CreateMap<PropertyType, PropertyTypeViewModel>();
            CreateMap<PropertyClass, PropertyClassViewModel>();
            CreateMap<ContactStaff, ContactStaffViewModel>();
            CreateMap<Photo, PhotoViewModel>();
            CreateMap<FloorPlan, FloorPlanViewModel>();
            CreateMap<FloorPlanFile, FloorPlanFilesViewModel>();
            CreateMap<PropertyFeature, PropertyFeatureViewModel>();
            CreateMap<PhoneNumber, PhoneNumberViewModel>();
            CreateMap<PropertyFeatureGrouping, PropertyFeatureGroupingViewModel>();
            CreateMap<Enquiry, EnquiryViewModel>();
            CreateMap<EssenceObjectRequiredApproval, EssenceObjectRequiredApprovalViewModel>();



            CreateMap<PropertyViewModel, Property>();
            CreateMap<SuburbViewModel, Suburb>();
            CreateMap<StateViewModel, State>();
            CreateMap<CountryViewModel, Country>();
            CreateMap<PropertyTypeViewModel, PropertyType>();
            CreateMap<PropertyClassViewModel, PropertyClass>();
            CreateMap<ContactStaffViewModel, ContactStaff>();
            CreateMap<PhotoViewModel, Photo>();
            CreateMap<FloorPlanViewModel, FloorPlan>();
            CreateMap<FloorPlanFilesViewModel, FloorPlanFile>();
            CreateMap<PropertyFeatureViewModel, PropertyFeature>();
            CreateMap<PropertyFeatureGroupingViewModel, PropertyFeatureGrouping>();
            CreateMap<PhoneNumberViewModel, PhoneNumber>();
            CreateMap<EnquiryViewModel, Enquiry>();
            CreateMap<EssenceObjectRequiredApprovalViewModel, EssenceObjectRequiredApproval>();

        }   
    }
}
