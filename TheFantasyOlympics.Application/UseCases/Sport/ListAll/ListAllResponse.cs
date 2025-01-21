using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Sport.ListAll
{
    public sealed record ListAllResponse(
        int Id,
        string Name,
        List<ModalityDto> Modalities
    );
}
