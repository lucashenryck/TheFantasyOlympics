using TheFantasyOlympics.Domain.Entities.Base;

namespace TheFantasyOlympics.Domain.Entities
{
    public sealed class Modality : Entity
    {
        public string Type { get; private set; } = string.Empty;
        public string Genre { get; private set; } = string.Empty;
        public int AllowedPlayersCount { get; private set; }
        public int SportId { get; private set; }
        public Sport? Sport { get; private set; } 
    }
}
