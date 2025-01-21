using MediatR;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Sport.Edit
{
    public class EditSportHandler(ISportRepository sportRepository) : IRequestHandler<EditSportRequest, EditSportResponse>
    {
        private readonly ISportRepository _sportRepository = sportRepository;

        public async Task<EditSportResponse> Handle(EditSportRequest request, CancellationToken cancellationToken)
        {
            var sport = await _sportRepository.FindById(request.Id, cancellationToken);

            if (sport == null) return new EditSportResponse("Sport not found.");

            if (!string.IsNullOrWhiteSpace(request.Name))
                sport.UpdateName(request.Name);

            await _sportRepository.EditAsync(sport);

            return new EditSportResponse("Sport updated.");
        }
    }
}
