using AutoMapper;

namespace TheFantasyOlympics.Application.UseCases.Modality.Register
{
    public class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            CreateMap<RegisterRequest, Domain.Entities.Athlete>();
        }
    }
}
