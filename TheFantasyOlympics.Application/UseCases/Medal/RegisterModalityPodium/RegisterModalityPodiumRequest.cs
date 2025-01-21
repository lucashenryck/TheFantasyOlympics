using MediatR;
using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Medal.RegisterModalityPodium
{
    public sealed record RegisterModalityPodiumRequest(RegisterModalityPodiumDto RegisterModalityPodium) : IRequest<RegisterModalityPodiumResponse>;
}
