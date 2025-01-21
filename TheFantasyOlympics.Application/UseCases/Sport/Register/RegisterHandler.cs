using AutoMapper;
using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Sport.Register
{
    public class RegisterHandler(ISportRepository sportRepository, IMapper mapper) : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        private readonly ISportRepository _sportRepository = sportRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var sport = _mapper.Map<Domain.Entities.Sport>(request);

            await _sportRepository.RegisterAsync(sport);

            return new RegisterResponse("Sport registered successfully.");
        }
    }
}
