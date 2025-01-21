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
            return await _context.Medals
            .Where(m => m.ModalityId == modalityId)
            .OrderBy(m => m.Position)
            .ToListAsync();
        }

        public async Task RegisterModalityPodiumAsync(List<Medal> podium)
        {
            await _context.Set<Medal>().AddRangeAsync(podium);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Medal>> ListByCountryAsync(string country, CancellationToken cancellationToken)
        {
            return await _context.Medals
            .Where(m => m.Country == country)
            .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Medal>> ListBySportAsync(int sportId, CancellationToken cancellationToken)
        {
            return await _context.Medals
            .Where(m => m.SportId == sportId)
            .ToListAsync(cancellationToken);
        }

        public async Task<List<MedalCountByCountry>> GetMedalTableAsync()
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
                .ToListAsync();

            return medalCounts;
        }
    }
}
