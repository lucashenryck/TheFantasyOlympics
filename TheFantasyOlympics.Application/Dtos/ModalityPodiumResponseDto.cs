namespace TheFantasyOlympics.Application.Dtos
{
    public class ModalityPodiumResponseDto(string modalityName, string podiumType, List<AthletePodiumPositionDto> podium)
    {
        public string ModalityName { get; set; } = modalityName;
        public string PodiumType { get; set; } = podiumType;
        public List<AthletePodiumPositionDto> Podium { get; set; } = podium;
    }
}
