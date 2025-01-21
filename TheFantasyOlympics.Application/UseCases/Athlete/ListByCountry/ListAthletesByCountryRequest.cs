using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListByCountry
{
    public sealed record ListAthletesByCountryRequest(string Country) : IRequest<List<ListAthletesByCountryResponse>>;
}
