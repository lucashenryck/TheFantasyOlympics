using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListBySport
{
    public class ListAthletesBySportHandler(IAthleteRepository athleteRepository) : IRequestHandler<ListAthletesBySportRequest, List<ListAthletesBySportResponse>>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<List<ListAthletesBySportResponse>> Handle(ListAthletesBySportRequest request, CancellationToken cancellationToken)
        {
            var athletes = await _athleteRepository.ListBySportAsync(request.SportId, cancellationToken);

            if (!athletes.Any())
                return [];

            var response = athletes.Select(athlete => new ListAthletesBySportResponse(
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
