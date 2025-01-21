using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Sport.Delete
{
    public class DeleteSportHandler(ISportRepository sportRepository) : IRequestHandler<DeleteSportRequest, DeleteSportResponse>
    {
        private readonly ISportRepository _sportRepository = sportRepository;

        public async Task<DeleteSportResponse> Handle(DeleteSportRequest request, CancellationToken cancellationToken)
        {
            var sport = await _sportRepository.FindById(request.Id, cancellationToken);

            if (sport == null) return new DeleteSportResponse("Sport not found.");

            await _sportRepository.DeleteAsync(sport);

            return new DeleteSportResponse("Sport deleted successfully.");
        }
    }
}
