using Microsoft.EntityFrameworkCore;
using TheFantasyOlympics.Domain.Entities.Base;
using TheFantasyOlympics.Domain.Interfaces.Repositories;
using TheFantasyOlympics.Persistence.Context;

namespace TheFantasyOlympics.Persistence.Repositories
{
    public class BaseEntityRepository<T>(AppDbContext context) : IBaseEntityRepository<T> where T : Entity
    {
        private readonly AppDbContext _context = context;

        public async Task RegisterAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T?> FindById(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
