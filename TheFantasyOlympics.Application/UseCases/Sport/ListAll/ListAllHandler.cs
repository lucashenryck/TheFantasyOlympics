using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Sport.ListAll
{
    public class ListAllHandler(ISportRepository sportRepository) : IRequestHandler<ListAllRequest, List<ListAllResponse>>
    {
        private readonly ISportRepository _sportRepository = sportRepository;

        public async Task<List<ListAllResponse>> Handle(ListAllRequest request, CancellationToken cancellationToken)
        {
            var sports = await _sportRepository.ListAllAsync(cancellationToken);

            if (!sports.Any())
                return [];

            var response = sports.Select(sport => new ListAllResponse(
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
