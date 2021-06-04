using AutoMapper;

namespace Hangar.HangarContracts
{
    public class HangarProfile : Profile
    {
        public HangarProfile()
        {
            CreateMap<Models.Hangar.Hangar, HangarContracts.Hangar>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ReverseMap();
        }
    }
}