using AutoMapper;

namespace TheFantasyOlympics.Application.UseCases.Sport.Register
{
    public sealed class RegisterSportMapper : Profile
    {
        public RegisterSportMapper()
        {
            CreateMap<RegisterSportRequest, Domain.Entities.Sport>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SportName));
        }
    }
}
