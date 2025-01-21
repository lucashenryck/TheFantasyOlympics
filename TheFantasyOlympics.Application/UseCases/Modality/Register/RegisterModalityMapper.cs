using AutoMapper;

namespace TheFantasyOlympics.Application.UseCases.Modality.Register
{
    public class RegisterModalityMapper : Profile
    {
        public RegisterModalityMapper()
        {
            CreateMap<RegisterModalityRequest, Domain.Entities.Modality>();
        }
    }
}
