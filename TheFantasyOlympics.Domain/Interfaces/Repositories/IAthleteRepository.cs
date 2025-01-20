using TheFantasyOlympics.Domain.Entities;

namespace TheFantasyOlympics.Domain.Interfaces.Repositories
{
    public interface IAthleteRepository : IBaseEntityRepository<Athlete>
    {
        Task<Athlete?> FindByIdAsync(int id);
        Task<IEnumerable<Athlete>> ListByCountryAsync(string country);
        Task<IEnumerable<Athlete>> ListBySportAsync(int sportId);
        Task<IEnumerable<Athlete>> ListByTeamAsync(string teamName);
    }
}
