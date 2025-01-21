using TheFantasyOlympics.Domain.Enumerations;

namespace TheFantasyOlympics.Domain.Entities
{
    public class Medal
    {
        public int Id { get; private set; }
        public Position Position { get; private set; }
        public string Country { get; set; } = string.Empty;
        public int SportId { get; set; }
        public Sport? Sport { get; set; }
        public int ModalityId { get; set; }
        public Modality? Modality { get; set; }

        public void SetPosition(Position position)
        {
            Position = position;
        }
    }
}
