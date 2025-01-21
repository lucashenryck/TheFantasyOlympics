using Microsoft.EntityFrameworkCore;
using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Enumerations;
using TheFantasyOlympics.Domain.Interfaces.Repositories;
using TheFantasyOlympics.Persistence.Context;

namespace TheFantasyOlympics.Persistence.Repositories
{
    public class MedalRepository(AppDbContext context) : IMedalRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Medal>> FindModalityPodiumAsync(int modalityId)
        {
            var positionOrder = new List<string> { "Gold", "Silver", "Bronze" };

            var medals = await _context.Medals
            .Include(m => m.Modality)
            .Include(m => m.Sport)
            .Where(m => m.ModalityId == modalityId)
            .OrderBy(m => m.Position)
            .ToListAsync();

            return [.. medals.OrderBy(m => positionOrder.IndexOf(m.Position.ToString()))];
        }

        public async Task RegisterModalityPodiumAsync(List<Medal> podium)
        {
            await _context.Set<Medal>().AddRangeAsync(podium);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Medal>> ListByCountryAsync(string country, CancellationToken cancellationToken)
        {
            return await _context.Medals
            .Include(m => m.Sport)
            .Include(m => m.Modality)
            .Where(m => m.Country == country)
            .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Medal>> ListBySportAsync(int sportId, CancellationToken cancellationToken)
        {
            return await _context.Medals
            .Include(m => m.Sport)
            .Include(m => m.Modality)
            .Where(m => m.SportId == sportId)
            .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<MedalCountByCountry>> GetMedalTableAsync(CancellationToken cancellationToken)
        {
            var medalCounts = await _context.Medals
                .GroupBy(m => m.Country)
                .Select(g => new MedalCountByCountry
                {
                    Country = g.Key,
                    Gold = g.Count(m => m.Position == Position.Gold),
                    Silver = g.Count(m => m.Position == Position.Silver),
                    Bronze = g.Count(m => m.Position == Position.Bronze)
                })
                .ToListAsync(cancellationToken);

            return medalCounts;
        }

        public async Task<Medal?> GetMedalByModalityAsync(int modalityId, Position position)
        {
            return await _context.Medals
                .FirstOrDefaultAsync(m => m.ModalityId == modalityId && m.Position == position);
        }
    }
}
