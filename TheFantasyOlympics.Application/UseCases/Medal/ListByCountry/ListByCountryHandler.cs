using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Medal.ListByCountry
{
    public class ListByCountryHandler(IMedalRepository medalRepository) : IRequestHandler<ListByCountryRequest, List<ListByCountryResponse>>
    {
        private readonly IMedalRepository _medalRepository = medalRepository;

        public async Task<List<ListByCountryResponse>> Handle(ListByCountryRequest request, CancellationToken cancellationToken)
        {
            var medals = await _medalRepository.ListByCountryAsync(request.CountryName, cancellationToken);

            if (!medals.Any())
                return [];

            var response = medals.Select(medal => new ListByCountryResponse(
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
