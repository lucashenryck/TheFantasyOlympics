using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Sport.Register
{
    public sealed record RegisterRequest(string SportName) : IRequest<RegisterResponse>;
}
