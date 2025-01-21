using TheFantasyOlympics.Domain.Entities.Base;

namespace TheFantasyOlympics.Domain.Entities
{
    public class Athlete : Entity
    {
        public string TeamName { get; private set; } = string.Empty;
        public string Country { get; private set; } = string.Empty;
        public int SportId { get; private set; }
        public Sport? Sport { get; private set; }
        public int ModalityId { get; private set; }
        public Modality? Modality { get; private set; }

        public void UpdateTeamName(string newTeamName)
        {
            TeamName = newTeamName;
        }

        public void UpdateCountry(string newCountry)
        {
            Country = newCountry;
        }

        public void UpdateSportId(int newSportId)
        {
            SportId = newSportId;
        }

        public void UpdateModalityId(int newModalityId)
        {
            ModalityId = newModalityId;
        }
    }
}
