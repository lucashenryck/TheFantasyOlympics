using Microsoft.EntityFrameworkCore;
using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Interfaces.Repositories;
using TheFantasyOlympics.Persistence.Context;

namespace TheFantasyOlympics.Persistence.Repositories
{
    public class SportRepository(AppDbContext context) : BaseEntityRepository<Sport>(context), ISportRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Sport?> FindById(int id, CancellationToken cancellationToken)
        {
            return await _context.Sports
                .Include(s => s.Modalities)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Sport>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Sports
                .Include(a => a.Modalities)
                .ToListAsync(cancellationToken);
        }
    }
}
