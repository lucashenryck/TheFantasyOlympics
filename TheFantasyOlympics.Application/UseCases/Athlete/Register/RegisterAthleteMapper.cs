using AutoMapper;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Register
{
    public sealed class RegisterAthleteMapper : Profile
    {
        public RegisterAthleteMapper()
        {
            CreateMap<RegisterAthleteRequest, Domain.Entities.Athlete>();
        }
    }
}
