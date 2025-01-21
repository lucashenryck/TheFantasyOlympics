using MediatR;
using TheFantasyOlympics.Domain.Enumerations;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Medal.RegisterModalityPodium
{
    public class RegisterModalityPodiumHandler(IMedalRepository medalRepository) : IRequestHandler<RegisterModalityPodiumRequest, RegisterModalityPodiumResponse>
    {
        private readonly IMedalRepository _medalRepository = medalRepository;

        public async Task<RegisterModalityPodiumResponse> Handle(RegisterModalityPodiumRequest request, CancellationToken cancellationToken)
        {
            var podium = new List<Domain.Entities.Medal>
            {
                new() {
                    Country = request.RegisterModalityPodium.Gold!.Country,
                    SportId = request.RegisterModalityPodium.Gold!.SportId,
                    ModalityId = request.RegisterModalityPodium.Gold!.ModalityId
                },
                new() {
                    Country = request.RegisterModalityPodium.Silver!.Country,
                    SportId = request.RegisterModalityPodium.Silver!.SportId,
                    ModalityId = request.RegisterModalityPodium.Silver!.ModalityId
                },
                new() {
                    Country = request.RegisterModalityPodium.Bronze!.Country,
                    SportId = request.RegisterModalityPodium.Bronze!.SportId,
                    ModalityId = request.RegisterModalityPodium.Bronze!.ModalityId
                }
            };

            foreach (var medal in podium)
            {
                var existingMedal = await _medalRepository.GetMedalByModalityAsync(medal.ModalityId, medal.GetPosition());

                if (existingMedal != null)
                    continue;

                if (medal.GetPosition() == Position.Gold)
                    medal.SetPosition(Position.Gold);
                else if (medal.GetPosition() == Position.Silver)
                    medal.SetPosition(Position.Silver);
                else if (medal.GetPosition() == Position.Bronze)
                    medal.SetPosition(Position.Bronze);
            }

            await _medalRepository.RegisterModalityPodiumAsync(podium);

            return new RegisterModalityPodiumResponse("Podium registered successfully.");
        }
    }
}
