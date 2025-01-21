using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListByCountry
{
    public class ListByCountryHandler(IAthleteRepository athleteRepository) : IRequestHandler<ListByCountryRequest, List<ListByCountryResponse>>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<List<ListByCountryResponse>> Handle(ListByCountryRequest request, CancellationToken cancellationToken)
        {
            var athletes = await _athleteRepository.ListByCountryAsync(request.Country);

            if (!athletes.Any())
                return [];

            var response = athletes.Select(athlete => new ListByCountryResponse(
                athlete.Id,
                athlete.Name,
                athlete.Country,
                athlete.TeamName,
                new SportDto(athlete.Sport!.Id, athlete.Sport.Name),
                new ModalityDto(athlete.Modality!.Id, athlete.Modality.Name)
            )).ToList();

            return response;
        }
    }
}
