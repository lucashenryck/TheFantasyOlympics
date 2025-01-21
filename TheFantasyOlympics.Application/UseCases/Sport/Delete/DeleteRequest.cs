using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Sport.Delete
{
    public sealed record DeleteRequest(int Id) : IRequest<DeleteResponse>;
}
