using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Sport.Edit
{
    public sealed record EditRequest(int Id, string Name) : IRequest<EditResponse>;
}
