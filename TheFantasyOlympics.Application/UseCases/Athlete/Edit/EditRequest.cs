using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Edit
{
    public sealed record EditRequest(
        int Id,
        string Name,
        string Country,
        string? TeamName,
        int SportId,
        int ModalityId
    )
    : IRequest<EditResponse>;
}
