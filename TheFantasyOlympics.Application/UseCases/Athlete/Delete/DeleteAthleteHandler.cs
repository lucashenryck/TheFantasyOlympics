using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Delete
{
    public class DeleteAthleteHandler(IAthleteRepository athleteRepository) : IRequestHandler<DeleteAthleteRequest, DeleteAthleteResponse>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<DeleteAthleteResponse> Handle(DeleteAthleteRequest request, CancellationToken cancellationToken)
        {
            var athlete = await _athleteRepository.FindById(request.Id, cancellationToken);

            if (athlete == null) return new DeleteAthleteResponse("Athlete not found.");

            await _athleteRepository.DeleteAsync(athlete);

            return new DeleteAthleteResponse("Athlete deleted successfully.");
        }
    }
}
