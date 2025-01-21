using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListByCountry
{
    public class ListAthletesByCountryHandler(IAthleteRepository athleteRepository) : IRequestHandler<ListAthletesByCountryRequest, List<ListAthletesByCountryResponse>>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<List<ListAthletesByCountryResponse>> Handle(ListAthletesByCountryRequest request, CancellationToken cancellationToken)
        {
            var athletes = await _athleteRepository.ListByCountryAsync(request.Country, cancellationToken);

            if (!athletes.Any())
                return [];

            var response = athletes.Select(athlete => new ListAthletesByCountryResponse(
                athlete.Id,
                athlete.Name,
                athlete.Country,
                athlete.TeamName,
                athlete.Gender.ToString(),
                new SportDto(athlete.Sport!.Id, athlete.Sport.Name),
                new ModalityDto(athlete.Modality!.Id, athlete.Modality.Name)
            )).ToList();

            return response;
        }
    }
}
