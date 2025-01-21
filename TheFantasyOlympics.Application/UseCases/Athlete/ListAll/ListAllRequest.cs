using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListAll
{
    public sealed record ListAllRequest : IRequest<List<ListAllResponse>>;
}
