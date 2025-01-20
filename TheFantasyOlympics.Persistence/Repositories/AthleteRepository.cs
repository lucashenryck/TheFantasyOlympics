using Microsoft.EntityFrameworkCore;
using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Interfaces.Repositories;
using TheFantasyOlympics.Persistence.Context;

namespace TheFantasyOlympics.Persistence.Repositories
{
    public class AthleteRepository(AppDbContext context) : BaseEntityRepository<Athlete>(context), IAthleteRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Athlete?> FindByIdAsync(int id)
        {
            return await _context.Athletes
                .Include(a => a.Sport)
                .Include(a => a.Modality)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Athlete>> ListByCountryAsync(string country)
        {
            return await _context.Athletes
                .Include(a => a.Sport)
                .Include(a => a.Modality)
                .Where(a => a.Country == country)
                .ToListAsync();
        }

        public async Task<IEnumerable<Athlete>> ListBySportAsync(int sportId)
        {
            return await _context.Athletes
                .Include(a => a.Sport)
                .Include(a => a.Modality)
                .Where(a => a.SportId == sportId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Athlete>> ListByTeamAsync(string teamName)
        {
            return await _context.Athletes
                .Include(a => a.Sport)
                .Include(a => a.Modality)
                .Where(a => a.TeamName == teamName)
                .ToListAsync();
        }
    }
}
