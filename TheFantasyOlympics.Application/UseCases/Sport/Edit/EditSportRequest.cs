using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Sport.Edit
{
    public sealed record EditSportRequest(int Id, string Name) : IRequest<EditSportResponse>;
}
