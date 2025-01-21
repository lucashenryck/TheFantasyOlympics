using TheFantasyOlympics.Domain.Entities;

namespace TheFantasyOlympics.Domain.Interfaces.Repositories
{
    public interface IMedalRepository
    {
        Task<IEnumerable<Medal>> FindModalityPodiumAsync(int modalityId);
        Task RegisterModalityPodiumAsync(List<Medal> podium);
        Task<IEnumerable<Medal>> ListByCountryAsync(string country, CancellationToken cancellationToken);
        Task<IEnumerable<Medal>> ListBySportAsync(int sportId, CancellationToken cancellationToken);
        Task<List<MedalCountByCountry>> GetMedalTableAsync();
    }
}
