using Microsoft.EntityFrameworkCore;
using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Enumerations;
using TheFantasyOlympics.Domain.Interfaces.Repositories;
using TheFantasyOlympics.Persistence.Context;

namespace TheFantasyOlympics.Persistence.Repositories
{
    public class AthleteRepository(AppDbContext context) : BaseEntityRepository<Athlete>(context), IAthleteRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Athlete>> ListByCountryAsync(string country, CancellationToken cancellationToken)
        {
            return await _context.Athletes
                .Include(a => a.Sport)
                .Include(a => a.Modality)
                .Where(a => a.Country == country)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Athlete>> ListBySportAsync(int sportId, CancellationToken cancellationToken)
        {
            return await _context.Athletes
                .Include(a => a.Sport)
                .Include(a => a.Modality)
                .Where(a => a.SportId == sportId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Athlete>> ListByTeamAsync(string teamName, CancellationToken cancellationToken)
        {
            return await _context.Athletes
                .Include(a => a.Sport)
                .Include(a => a.Modality)
                .Where(a => a.TeamName == teamName)
                .ToListAsync(cancellationToken);
        }

        public async Task<Athlete?> FindById(int id, CancellationToken cancellationToken)
        {
            return await _context.Athletes
                .Include(a => a.Sport)
                .Include(a => a.Modality)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Athlete>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Athletes
                .Include(a => a.Sport)
                .Include(a => a.Modality)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Athletes.AnyAsync(a => a.Name == name);
        }

        public async Task<bool> HasAthleteWithGenderAsync(string teamName, string gender)
        {
            return await _context.Set<Athlete>()
                .AnyAsync(a => a.TeamName == teamName && a.Gender.ToString() == gender);
        }
    }
}
