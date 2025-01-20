using TheFantasyOlympics.Domain.Entities;

namespace TheFantasyOlympics.Domain.Interfaces.Repositories
{
    public interface ISportRepository : IBaseEntityRepository<Sport>
    {
        Task<Modality?> FindModalityPodiumAsync(int modalityId);
        Task RegisterModalityPodiumAsync(int modalityId, IEnumerable<Athlete> podiumAthletes);
    }
}
