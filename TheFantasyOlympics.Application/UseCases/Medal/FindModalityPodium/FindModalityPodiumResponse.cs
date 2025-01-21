using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Medal.FindModalityPodium
{
    public sealed record FindModalityPodiumResponse(
        int Id,
        string Position,
        string Country,
        SportDto Sport,
        ModalityDto Modality
    );
}
