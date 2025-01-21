using Microsoft.EntityFrameworkCore;
using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Enumerations;

namespace TheFantasyOlympics.Domain.Interfaces.Repositories
{
    public interface IMedalRepository
    {
        Task<IEnumerable<Medal>> FindModalityPodiumAsync(int modalityId);
        Task RegisterModalityPodiumAsync(List<Medal> podium);
        Task<IEnumerable<Medal>> ListByCountryAsync(string country, CancellationToken cancellationToken);
        Task<IEnumerable<Medal>> ListBySportAsync(int sportId, CancellationToken cancellationToken);
        Task<IEnumerable<MedalCountByCountry>> GetMedalTableAsync(CancellationToken cancellationToken);
        Task<Medal?> GetMedalByModalityAsync(int modalityId, Position position);
    }
}
