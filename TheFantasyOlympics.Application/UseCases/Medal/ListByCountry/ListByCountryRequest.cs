using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Medal.ListByCountry
{
    public sealed record ListByCountryRequest(string CountryName) : IRequest<List<ListByCountryResponse>>;
}
