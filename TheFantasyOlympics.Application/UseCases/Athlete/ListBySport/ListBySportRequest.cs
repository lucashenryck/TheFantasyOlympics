using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListBySport
{
    public sealed record ListBySportRequest(int SportId) : IRequest<List<ListBySportResponse>>;
}
