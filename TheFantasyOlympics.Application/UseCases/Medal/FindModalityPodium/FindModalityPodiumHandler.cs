using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Medal.FindModalityPodium
{
    public class FindModalityPodiumHandler(IMedalRepository medalRepository) : IRequestHandler<FindModalityPodiumRequest, List<FindModalityPodiumResponse>>
    {
        private readonly IMedalRepository _medalRepository = medalRepository;

        public async Task<List<FindModalityPodiumResponse>> Handle(FindModalityPodiumRequest request, CancellationToken cancellationToken)
        {
            var podiumMedals = await _medalRepository.FindModalityPodiumAsync(request.ModalityId);

            if (!podiumMedals.Any())
                return [];

            var response = podiumMedals.Select(podiumMedal => new FindModalityPodiumResponse(
                podiumMedal.Id,
                podiumMedal.Position.ToString(),
                podiumMedal.Country,
                new SportDto(podiumMedal.Sport!.Id, podiumMedal.Sport.Name),
                new ModalityDto(podiumMedal.Modality!.Id, podiumMedal.Modality.Name)
            )).ToList();

            return response;
        }
    }
}
