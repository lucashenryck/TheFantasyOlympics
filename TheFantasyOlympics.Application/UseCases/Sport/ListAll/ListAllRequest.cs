using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Sport.ListAll
{
    public sealed record ListAllRequest : IRequest<List<ListAllResponse>>;
}
