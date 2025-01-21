using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Edit
{
    public class EditHandler(IAthleteRepository athleteRepository) : IRequestHandler<EditRequest, EditResponse>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<EditResponse> Handle(EditRequest request, CancellationToken cancellationToken)
        {
            var athlete = await _athleteRepository.FindById(request.Id, cancellationToken);

            if (athlete == null) return new EditResponse { Message = "Athlete not found." };

            if (!string.IsNullOrWhiteSpace(request.Name))
                athlete.UpdateName(request.Name);

            if (!string.IsNullOrWhiteSpace(request.Country))
                athlete.UpdateCountry(request.Country);

            if (!string.IsNullOrWhiteSpace(request.TeamName))
                athlete.UpdateTeamName(request.TeamName);

            if (request.SportId != 0)
                athlete.UpdateSportId(request.SportId);

            if (request.ModalityId != 0)
                athlete.UpdateModalityId(request.ModalityId);

            await _athleteRepository.EditAsync(athlete);

            return new EditResponse { Message = "Athlete not found." };
        }
    }
}
