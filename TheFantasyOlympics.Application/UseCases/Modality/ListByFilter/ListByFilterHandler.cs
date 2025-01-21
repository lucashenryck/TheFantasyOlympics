using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Modality.ListByFilter
{
    public class ListByFilterHandler(IModalityRepository modalityRepository) : IRequestHandler<ListByFilterRequest, List<ListByFilterResponse>>
    {
        private readonly IModalityRepository _modalityRepository = modalityRepository;

        public async Task<List<ListByFilterResponse>> Handle(ListByFilterRequest request, CancellationToken cancellationToken)
        {
            var modalities = await _modalityRepository.ListByFilterAsync(request.SportId, request.Type, request.Genre);

            if (!modalities.Any())
                return [];

            var response = modalities.Select(modality => new ListByFilterResponse(
                modality.Id,
                modality.Name,
                modality.Type.ToString(),
                modality.Genre.ToString(),
                modality.AllowedPlayersCount,
                new SportDto(modality.Sport!.Id, modality.Sport.Name)
            )).ToList();

            return response;
        }
    }
}
