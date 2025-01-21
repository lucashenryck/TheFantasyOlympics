using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Medal.GetTable
{
    public sealed record GetTableResponse
    {
        public List<MedalCountByCountryDto>? Gold { get; set; }
        public List<MedalCountByCountryDto>? Silver { get; set; }
        public List<MedalCountByCountryDto>? Bronze { get; set; }
    }
}
