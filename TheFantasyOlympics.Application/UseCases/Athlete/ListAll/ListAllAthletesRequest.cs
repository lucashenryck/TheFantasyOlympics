using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListAll
{
    public sealed record ListAllAthletesRequest : IRequest<List<ListAllAthletesResponse>>;
}
