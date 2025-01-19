using TheFantasyOlympics.Domain.Entities.Base;

namespace TheFantasyOlympics.Domain.Entities
{
    public class Athlete : Entity
    {
        public string Country { get; private set; } = string.Empty;
        public string TeamName { get; private set; } = string.Empty;
        public int SportId { get; private set; }
        public Sport? Sport { get; private set; }
        public int ModalityId { get; private set; }
        public Modality? Modality { get; private set; } 
    }
}
