using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Sport.Register
{
    public sealed record RegisterSportRequest(string SportName) : IRequest<RegisterSportResponse>;
}
