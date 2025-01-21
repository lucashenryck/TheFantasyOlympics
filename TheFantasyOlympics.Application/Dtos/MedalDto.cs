namespace TheFantasyOlympics.Application.Dtos
{
    public class MedalDto
    {
        public string Country { get; set; } = string.Empty;
        public int SportId { get; set; }
        public int ModalityId { get; set; }
    }
}
