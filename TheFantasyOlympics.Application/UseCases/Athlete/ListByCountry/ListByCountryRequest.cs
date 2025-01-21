using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.ListByCountry
{
    public sealed record ListByCountryRequest(string Country) : IRequest<List<ListByCountryResponse>>;
}
