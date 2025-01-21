using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListBySport
{
    public sealed record ListBySportResponse(
        int Id,
        string Name,
        string Country,
        string? TeamName,
        SportDto Sport,
        ModalityDto Modality
    );
}
