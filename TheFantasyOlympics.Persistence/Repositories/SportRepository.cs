using TheFantasyOlympics.Domain.Entities;
using TheFantasyOlympics.Domain.Interfaces.Repositories;
using TheFantasyOlympics.Persistence.Context;

namespace TheFantasyOlympics.Persistence.Repositories
{
    public class SportRepository(AppDbContext context) : BaseEntityRepository<Sport>(context), ISportRepository
    {
    }
}
