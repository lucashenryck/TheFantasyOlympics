using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListByCountry
{
    public sealed record ListByCountryResponse(
        int Id,
        string Name,
        string Country,
        string? TeamName,
        SportDto Sport,
        ModalityDto Modality
    );
}
