namespace TheFantasyOlympics.Domain.Entities
{
    public class MedalCountByCountry
    {
        public string Country { get; set; } = string.Empty;
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Bronze { get; set; }
    }
}
