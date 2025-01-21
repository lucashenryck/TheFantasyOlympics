using TheFantasyOlympics.Domain.Entities;

namespace TheFantasyOlympics.Domain.Interfaces.Repositories
{
    public interface ISportRepository : IBaseEntityRepository<Sport>
    {
        Task<Sport?> FindById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Sport>> ListAllAsync(CancellationToken cancellationToken);
    }
}
