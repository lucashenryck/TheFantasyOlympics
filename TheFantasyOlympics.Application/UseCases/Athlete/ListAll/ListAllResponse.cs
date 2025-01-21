using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListAll
{
    public sealed record ListAllResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
        public SportDto? Sport { get; set; }
        public ModalityDto? Modality { get; set; }
    }
}
