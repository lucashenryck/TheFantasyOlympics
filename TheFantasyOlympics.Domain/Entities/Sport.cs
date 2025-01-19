using TheFantasyOlympics.Domain.Entities.Base;

namespace TheFantasyOlympics.Domain.Entities
{
    public sealed class Sport : Entity
    {
        public ICollection<Modality> Modalities { get; private set; } = [];
    }
}
