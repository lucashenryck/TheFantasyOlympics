using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListByCountry
{
    public sealed record ListAthletesByCountryResponse(
        int Id,
        string Name,
        string Country,
        string? TeamName,
        string Gender,
        SportDto Sport,
        ModalityDto Modality
    );
}
