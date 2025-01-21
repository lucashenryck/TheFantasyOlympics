using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Sport.Delete
{
    public sealed record DeleteSportRequest(int Id) : IRequest<DeleteSportResponse>;
}
