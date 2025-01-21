using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Register
{
    public sealed record RegisterAthleteRequest(
        string Name, 
        string Country, 
        string? TeamName, 
        string Gender,
        int SportId, 
        int ModalityId
    ) 
    : IRequest<RegisterAthleteResponse>;
}
