using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Register
{
    public sealed record RegisterRequest(
        string Name, 
        string Country, 
        string? TeamName, 
        int SportId, 
        int ModalityId
    ) 
    : IRequest<RegisterResponse>;
}
