using Microsoft.EntityFrameworkCore;
using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Interfaces.Repositories;
using TheFantasyOlympics.Persistence.Context;

namespace TheFantasyOlympics.Persistence.Repositories
{
    public class ModalityRepository(AppDbContext context) : BaseEntityRepository<Modality>(context), IModalityRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Modality>> ListByFilterAsync(int? sportId, string? type, string? genre)
        {
            var query = _context.Modalities.AsQueryable();

            if (sportId.HasValue)
                query = query.Where(m => m.SportId == sportId.Value);

            if (!string.IsNullOrEmpty(type))
                query = query.Where(m => m.Type.ToString().Equals(type, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(m => m.Genre.ToString().Equals(genre, StringComparison.OrdinalIgnoreCase));

            return await query.ToListAsync();
        }
    }
}
