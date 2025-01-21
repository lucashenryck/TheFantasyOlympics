using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Sport.Edit
{
    public class EditHandler(ISportRepository sportRepository) : IRequestHandler<EditRequest, EditResponse>
    {
        private readonly ISportRepository _sportRepository = sportRepository;

        public async Task<EditResponse> Handle(EditRequest request, CancellationToken cancellationToken)
        {
            var sport = await _sportRepository.FindById(request.Id, cancellationToken);

            if (sport == null) return new EditResponse("Sport not found.");

            if (!string.IsNullOrWhiteSpace(request.Name))
                sport.UpdateName(request.Name);

            await _sportRepository.EditAsync(sport);

            return new EditResponse("Sport updated.");
        }
    }
}
