using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Edit
{
    public class EditAthleteHandler(IAthleteRepository athleteRepository) : IRequestHandler<EditAthleteRequest, EditAthleteResponse>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<EditAthleteResponse> Handle(EditAthleteRequest request, CancellationToken cancellationToken)
        {
            var athlete = await _athleteRepository.FindById(request.Id, cancellationToken);

            if (athlete == null) return new EditAthleteResponse { Message = "Athlete not found." };

            if (!string.IsNullOrWhiteSpace(request.Name) && request.Name != "string" && request.Name != athlete.Name)
                athlete.UpdateName(request.Name);

            if (!string.IsNullOrWhiteSpace(request.Country) && request.Country != "string" && request.Country != athlete.Country)
                athlete.UpdateCountry(request.Country);

            if (!string.IsNullOrWhiteSpace(request.TeamName) && request.TeamName != "string" && request.TeamName != athlete.TeamName)
                athlete.UpdateTeamName(request.TeamName);

            if (request.SportId.HasValue && request.SportId.Value > 0 && request.SportId.Value != athlete.SportId)
                athlete.UpdateSportId(request.SportId.Value);

            if (request.ModalityId.HasValue && request.ModalityId.Value > 0 && request.ModalityId.Value != athlete.ModalityId)
                athlete.UpdateModalityId(request.ModalityId.Value);

            await _athleteRepository.EditAsync(athlete);

            return new EditAthleteResponse { Message = "Athlete updated successfully." };
        }
    }
}
