using AutoMapper;
using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Modality.Register
{
    public class RegisterHandler(IModalityRepository modalityRepository, IMapper mapper) : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        private readonly IModalityRepository _modalityRepository = modalityRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var modality = _mapper.Map<Domain.Entities.Modality>(request);

            await _modalityRepository.RegisterAsync(modality);

            return new RegisterResponse("Modality registered successfully.");
        }
    }
}
