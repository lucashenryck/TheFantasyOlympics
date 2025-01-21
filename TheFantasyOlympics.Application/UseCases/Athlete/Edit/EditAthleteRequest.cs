using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Edit
{
    public sealed record EditAthleteRequest(
        int Id,                  
        string? Name = null,     
        string? Country = null,
        string? TeamName = null,
        int? SportId = null,     
        int? ModalityId = null
    ) 
    : IRequest<EditAthleteResponse>;
}
