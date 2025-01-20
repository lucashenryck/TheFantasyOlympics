using TheFantasyOlympics.Domain.Entities;

namespace TheFantasyOlympics.Domain.Interfaces.Repositories
{
    public interface IModalityRepository
    {
        Task RegisterAsync(Modality modality);
        Task<IEnumerable<Modality>> ListModalitiesBySportAsync(int sportId, string? type, string? genre);
        Task<Modality?> FindModalityPodiumAsync(int modalityId);
    }
}
