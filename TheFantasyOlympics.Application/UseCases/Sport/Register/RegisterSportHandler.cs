using AutoMapper;
using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Sport.Register
{
    public class RegisterSportHandler(ISportRepository sportRepository, IMapper mapper) : IRequestHandler<RegisterSportRequest, RegisterSportResponse>
    {
        private readonly ISportRepository _sportRepository = sportRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<RegisterSportResponse> Handle(RegisterSportRequest request, CancellationToken cancellationToken)
        {
            var sport = _mapper.Map<Domain.Entities.Sport>(request);

            await _sportRepository.RegisterAsync(sport);

            return new RegisterSportResponse("Sport registered successfully.");
        }
    }
}
