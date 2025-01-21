using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Modality.ListByFilter
{
    public sealed record ListByFilterRequest(int SportId, string? Type, string? Genre) : IRequest<List<ListByFilterResponse>>;
}
