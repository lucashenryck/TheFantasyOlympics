using AutoMapper;
using MediatR;
using TheFantasyOlympics.Domain.Enumerations;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Athlete.Register
{
    public class RegisterAthleteHandler(IAthleteRepository athleteRepository, IModalityRepository modalityRepository,  IMapper mapper) : IRequestHandler<RegisterAthleteRequest, RegisterAthleteResponse>
    {
        private readonly IAthleteRepository _athleteRepository = athleteRepository;
        private readonly IModalityRepository _modalityRepository = modalityRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<RegisterAthleteResponse> Handle(RegisterAthleteRequest request, CancellationToken cancellationToken)
        {
            bool athleteExists = await _athleteRepository.ExistsAsync(request.Name);

            if (athleteExists)
                return new RegisterAthleteResponse("Athlete is already registered.");

            var modality = await _modalityRepository.GetByIdAsync(request.ModalityId);

            if (modality == null)
                return new RegisterAthleteResponse("Invalid modality.");

            if (modality.Genre == Genre.Mixed && modality.Type == Domain.Enumerations.Type.Team)
            {
                bool hasMale = await _athleteRepository.HasAthleteWithGenderAsync(request.TeamName!, Gender.Male.ToString());
                bool hasFemale = await _athleteRepository.HasAthleteWithGenderAsync(request.TeamName!, Gender.Female.ToString());

                if (!hasMale || !hasFemale)
                    return new RegisterAthleteResponse("In a mixed modality, the team must have at least one male and one female athlete.");
            }

            if (modality.Type == Domain.Enumerations.Type.Individual || modality.Type == Domain.Enumerations.Type.Double)
                request = request with { TeamName = "NA" };

            var athlete = _mapper.Map<Domain.Entities.Athlete>(request);

            await _athleteRepository.RegisterAsync(athlete);

            return new RegisterAthleteResponse("Athlete registered successfully.");
        }
    }
}
