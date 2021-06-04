using AutoMapper;
using Hangar.Orchestrators.Plane;

namespace Hangar.PlaneContracts
{
    public class AirCraftProfile : Profile
    {
        public AirCraftProfile()
        {
            CreateMap<Models.Plane.AirCraft, AirCraft>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StorageData, opt => opt.MapFrom(src => src.StorageData))
                .ReverseMap();
        }
    }
}