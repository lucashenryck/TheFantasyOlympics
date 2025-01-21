using AutoMapper;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Register
{
    public sealed class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            CreateMap<RegisterRequest, Domain.Entities.Athlete>();
        }
    }
}
