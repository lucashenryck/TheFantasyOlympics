using Microsoft.EntityFrameworkCore;
using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Interfaces.Repositories;
using TheFantasyOlympics.Persistence.Context;

namespace TheFantasyOlympics.Persistence.Repositories
{
    public class ModalityRepository(AppDbContext context) : BaseEntityRepository<Modality>(context), IModalityRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Modality>> ListByFilterAsync(int sportId, string? type, string? genre, CancellationToken cancellationToken)
        {
            var query = _context.Modalities
                .Include(m => m.Sport)
                .AsQueryable();

            query = query.Where(m => m.SportId == sportId);

            if (!string.IsNullOrEmpty(type))
                query = query.Where(m => m.Type.ToString().Equals(type, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(m => m.Genre.ToString().Equals(genre, StringComparison.OrdinalIgnoreCase));

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Modality?> GetByIdAsync(int modalityId)
        {
            return await _context.Set<Modality>().FirstOrDefaultAsync(m => m.Id == modalityId);
        }
    }
}
