using TheFantasyOlympics.Domain.Entities;

namespace TheFantasyOlympics.Domain.Interfaces.Repositories
{
    public interface IModalityRepository : IBaseEntityRepository<Modality>
    {
        Task<IEnumerable<Modality>> ListByFilterAsync(int? sportId, string? type, string? genre);
    }
}
