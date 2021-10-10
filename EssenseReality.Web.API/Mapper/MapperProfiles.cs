using EssenseReality.Domain.Models;
using EssenseReality.Domain.ViewModels;
using AutoMapper;

namespace EssenseReality.Web.API.Mapper
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
            CreateMap<PropertyFeature, PropertyFeatureViewModel>();


            CreateMap<PropertyViewModel, Property>();

        }   
    }
}
