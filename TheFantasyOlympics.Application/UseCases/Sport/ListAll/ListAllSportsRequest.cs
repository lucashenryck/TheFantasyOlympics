using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Sport.ListAll
{
    public sealed record ListAllSportsRequest : IRequest<List<ListAllSportsResponse>>;
}
