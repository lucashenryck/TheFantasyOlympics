using AutoMapper;

namespace TheFantasyOlympics.Application.UseCases.Sport.Register
{
    public sealed class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            CreateMap<RegisterRequest, Domain.Entities.Sport>();
        }
    }
}
