using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListByTeam
{
    public class ListByTeamHandler(IAthleteRepository athleteRepository) : IRequestHandler<ListByTeamRequest, List<ListByTeamResponse>>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<List<ListByTeamResponse>> Handle(ListByTeamRequest request, CancellationToken cancellationToken)
        {
            var athletes = await _athleteRepository.ListByTeamAsync(request.TeamName, cancellationToken);

            if (!athletes.Any())
                return [];

            var response = athletes.Select(athlete => new ListByTeamResponse(
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
