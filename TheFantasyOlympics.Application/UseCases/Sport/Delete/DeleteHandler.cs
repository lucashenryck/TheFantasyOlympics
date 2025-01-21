using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Sport.Delete
{
    public class DeleteHandler(ISportRepository sportRepository) : IRequestHandler<DeleteRequest, DeleteResponse>
    {
        private readonly ISportRepository _sportRepository = sportRepository;

        public async Task<DeleteResponse> Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            var sport = await _sportRepository.FindById(request.Id, cancellationToken);

            if (sport == null) return new DeleteResponse("Sport not found.");

            await _sportRepository.DeleteAsync(sport);

            return new DeleteResponse("Sport deleted successfully.");
        }
    }
}
