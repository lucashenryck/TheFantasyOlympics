using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Athlete.FindById
{
    public sealed record FindByIdResponse(
        int Id,
        string Name,
        string Country,
        string? TeamName,
        SportDto Sport,
        ModalityDto Modality
    );
}
