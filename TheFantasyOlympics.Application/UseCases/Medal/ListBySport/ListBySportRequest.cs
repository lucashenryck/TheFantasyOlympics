using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Medal.ListBySport
{
    public sealed record ListBySportRequest(int SportId) : IRequest<List<ListBySportResponse>>;
}
