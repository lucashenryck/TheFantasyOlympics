using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListAll
{
    public class ListAllHandler(IAthleteRepository athleteRepository) : IRequestHandler<ListAllRequest, List<ListAllResponse>>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<List<ListAllResponse>> Handle(ListAllRequest request, CancellationToken cancellationToken)
        {
            var athletes = await _athleteRepository.ListAllAsync(cancellationToken);

            if (!athletes.Any())
                return [];

            var response = athletes.Select(athlete => new ListAllResponse
            {
                Id = athlete.Id,
                Name = athlete.Name,
                Country = athlete.Country,
                TeamName = athlete.TeamName,
                Sport = new SportDto(athlete.Sport!.Id, athlete.Sport.Name),
                Modality = new ModalityDto(athlete.Modality!.Id, athlete.Modality.Name)
            }).ToList();

            return response;
        }
    }
}
