using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Modality.Register
{
    public sealed record RegisterModalityRequest(
        int SportId, 
        string Name, 
        string Type, 
        string Genre, 
        int AllowedPlayersCount
    )
    : IRequest<RegisterModalityResponse>;
}
