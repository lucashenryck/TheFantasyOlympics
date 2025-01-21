using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Delete
{
    public sealed record DeleteAthleteRequest(int Id) : IRequest<DeleteAthleteResponse>;
}
