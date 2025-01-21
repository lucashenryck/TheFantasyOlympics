using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Enumerations;

namespace TheFantasyOlympics.Domain.Interfaces.Repositories
{
    public interface IAthleteRepository : IBaseEntityRepository<Athlete>
    {
        Task<Athlete?> FindById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Athlete>> ListAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Athlete>> ListByCountryAsync(string country, CancellationToken cancellationToken);
        Task<IEnumerable<Athlete>> ListBySportAsync(int sportId, CancellationToken cancellationToken);
        Task<IEnumerable<Athlete>> ListByTeamAsync(string teamName, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(string name);
        Task<bool> HasAthleteWithGenderAsync(string teamName, string gender);
    }
}
