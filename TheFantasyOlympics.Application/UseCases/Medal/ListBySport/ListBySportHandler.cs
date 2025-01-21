using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Medal.ListBySport
{
    public class ListByCountryHandler(IMedalRepository medalRepository) : IRequestHandler<ListBySportRequest, List<ListBySportResponse>>
    {
        private readonly IMedalRepository _medalRepository = medalRepository;

        public async Task<List<ListBySportResponse>> Handle(ListBySportRequest request, CancellationToken cancellationToken)
        {
            var medals = await _medalRepository.ListBySportAsync(request.SportId, cancellationToken);

            if (!medals.Any())
                return [];

            var response = medals.Select(medal => new ListBySportResponse(
                medal.Id,
                medal.Position.ToString(),
                medal.Country,
                new SportDto(medal.Sport!.Id, medal.Sport.Name),
                new ModalityDto(medal.Modality!.Id, medal.Modality.Name)
            )).ToList();

            return response;
        }
    }
}
