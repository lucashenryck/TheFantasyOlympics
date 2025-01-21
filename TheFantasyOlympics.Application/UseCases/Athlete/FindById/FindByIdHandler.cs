using AutoMapper;
using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.FindById
{
    public class FindByIdHandler(IAthleteRepository athleteRepository) : IRequestHandler<FindByIdRequest, FindByIdResponse> 
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;

        public async Task<FindByIdResponse> Handle(FindByIdRequest request, CancellationToken cancellationToken)
        {
            var athlete = await _athleteRepository.FindById(request.Id, cancellationToken) ?? throw new Exception("Athlete not found.");

            return new FindByIdResponse(
                athlete.Id,
                athlete.Name,
                athlete.Country,
                athlete.TeamName,
                new SportDto(athlete.Sport!.Id, athlete.Sport.Name),
                new ModalityDto(athlete.Modality!.Id, athlete.Modality.Name)
            );
        }
    }
}
