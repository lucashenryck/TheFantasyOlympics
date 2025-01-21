using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Sport.ListAll
{
    public sealed record ListAllSportsResponse(
        int Id,
        string Name,
        List<ModalityDto> Modalities
    );
}
