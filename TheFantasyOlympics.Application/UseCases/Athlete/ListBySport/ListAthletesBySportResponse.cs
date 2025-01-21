using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListBySport
{
    public sealed record ListAthletesBySportResponse(
        int Id,
        string Name,
        string Country,
        string? TeamName,
        string Gender,
        SportDto Sport,
        ModalityDto Modality
    );
}
