using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Sport.ListAll
{
    public class ListAllSportsHandler(ISportRepository sportRepository) : IRequestHandler<ListAllSportsRequest, List<ListAllSportsResponse>>
    {
        private readonly ISportRepository _sportRepository = sportRepository;

        public async Task<List<ListAllSportsResponse>> Handle(ListAllSportsRequest request, CancellationToken cancellationToken)
        {
            var sports = await _sportRepository.ListAllAsync(cancellationToken);

            if (!sports.Any())
                return [];

            var response = sports.Select(sport => new ListAllSportsResponse(
                sport.Id,
                sport.Name,
                sport.Modalities.Select(modality => new ModalityDto(
                    modality.Id,
                    modality.Name
                )).ToList()
            )).ToList();

            return response;
        }
    }
}
