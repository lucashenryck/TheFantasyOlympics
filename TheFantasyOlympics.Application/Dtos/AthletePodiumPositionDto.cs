namespace TheFantasyOlympics.Application.Dtos
{
    public class AthletePodiumPositionDto
    {
        public string Position { get; set; } = string.Empty;
        public string? AthleteName { get; set; }
        public string? TeamName { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
