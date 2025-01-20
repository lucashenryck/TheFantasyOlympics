using TheFantasyOlympics.Domain.Entities.Base;

namespace TheFantasyOlympics.Domain.Interfaces.Repositories
{
    public interface IBaseEntityRepository<T> where T : Entity
    {
        Task RegisterAsync(T entity);
        Task EditAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
    }
}
