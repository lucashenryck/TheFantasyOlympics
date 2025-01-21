using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListBySport
{
    public sealed record ListAthletesBySportRequest(int SportId) : IRequest<List<ListAthletesBySportResponse>>;
}
