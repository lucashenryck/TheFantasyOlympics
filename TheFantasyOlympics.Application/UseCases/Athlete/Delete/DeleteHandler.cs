using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Delete
{
    public class DeleteHandler(IAthleteRepository athleteRepository) : IRequestHandler<DeleteRequest, DeleteResponse>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<DeleteResponse> Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            var athlete = await _athleteRepository.FindById(request.Id, cancellationToken);

            if (athlete == null) return new DeleteResponse("Athlete not found.");

            await _athleteRepository.DeleteAsync(athlete);

            return new DeleteResponse("Athlete deleted successfully.");
        }
    }
}
