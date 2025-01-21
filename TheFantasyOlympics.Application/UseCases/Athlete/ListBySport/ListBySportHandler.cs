using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListBySport
{
    public class ListBySportHandler(IAthleteRepository athleteRepository) : IRequestHandler<ListBySportRequest, List<ListBySportResponse>>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<List<ListBySportResponse>> Handle(ListBySportRequest request, CancellationToken cancellationToken)
        {
            var athletes = await _athleteRepository.ListBySportAsync(request.SportId);

            if (!athletes.Any())
                return [];

            var response = athletes.Select(athlete => new ListBySportResponse(
                athlete.Id,
                athlete.Name,
                athlete.Country,
                athlete.TeamName,
                new SportDto(athlete.Sport!.Id, athlete.Sport.Name),
                new ModalityDto(athlete.Modality!.Id, athlete.Modality.Name)
            )).ToList();

            return response;
        }
    }
}
