using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Medal.ListByCountry
{
    public sealed record ListMedalsByCountryResponse(
        int Id,
        string Position,
        string Country,
        SportDto Sport,
        ModalityDto Modality
    );
}
