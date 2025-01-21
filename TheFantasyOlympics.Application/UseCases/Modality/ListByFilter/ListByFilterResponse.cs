using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Modality.ListByFilter
{
    public sealed record ListByFilterResponse(
        int Id,
        string Name,
        string Type,
        string Genre,
        int AllowedPlayersCount,
        SportDto Sport
    );
}
