using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListByTeam
{
    public sealed record ListByTeamResponse(
        int Id,
        string Name,
        string Country,
        string? TeamName,
        SportDto Sport,
        ModalityDto Modality
    );
}
