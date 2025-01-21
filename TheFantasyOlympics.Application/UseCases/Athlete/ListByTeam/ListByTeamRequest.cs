using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListByTeam
{
    public sealed record ListByTeamRequest(string TeamName) : IRequest<List<ListByTeamResponse>>;
}
