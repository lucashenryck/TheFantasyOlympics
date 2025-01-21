using AutoMapper;
using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Register
{
    public class RegisterHandler(IAthleteRepository athleteRepository, IMapper mapper) : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var athlete = _mapper.Map<Domain.Entities.Athlete>(request);

            await _athleteRepository.RegisterAsync(athlete);

            return new RegisterResponse("Athlete registered successfully.");
        }
    }
}
