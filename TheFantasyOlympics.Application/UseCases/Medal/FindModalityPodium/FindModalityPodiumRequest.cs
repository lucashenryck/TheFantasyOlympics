using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Medal.FindModalityPodium
{
    public sealed record FindModalityPodiumRequest(int ModalityId) : IRequest<List<FindModalityPodiumResponse>>;
}
