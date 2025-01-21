using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Delete
{
    public sealed record DeleteRequest(int Id) : IRequest<DeleteResponse>;
}
