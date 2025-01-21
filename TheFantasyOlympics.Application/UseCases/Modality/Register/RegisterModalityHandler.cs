using AutoMapper;
using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Modality.Register
{
    public class RegisterModalityHandler(IModalityRepository modalityRepository, IMapper mapper) : IRequestHandler<RegisterModalityRequest, RegisterModalityResponse>
    {
        private readonly IModalityRepository _modalityRepository = modalityRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<RegisterModalityResponse> Handle(RegisterModalityRequest request, CancellationToken cancellationToken)
        {
            var modality = _mapper.Map<Domain.Entities.Modality>(request);

            await _modalityRepository.RegisterAsync(modality);

            return new RegisterModalityResponse("Modality registered successfully.");
        }
    }
}
