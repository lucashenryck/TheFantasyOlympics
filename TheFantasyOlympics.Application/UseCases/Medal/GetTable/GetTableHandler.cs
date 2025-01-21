using MediatR;
using TheFantasyOlympics.Application.Dtos;
using TheFantasyOlympics.Domain.Interfaces.Repositories;

namespace TheFantasyOlympics.Application.UseCases.Medal.GetTable
{
    public class GetTableHandler(IMedalRepository medalRepository) : IRequestHandler<GetTableRequest, GetTableResponse>
    {
        private readonly IMedalRepository _medalRepository = medalRepository;

        public async Task<GetTableResponse> Handle(GetTableRequest request, CancellationToken cancellationToken)
        {
            var medalCounts = await _medalRepository.GetMedalTableAsync();

            var goldMedals = medalCounts
                .OrderByDescending(m => m.Gold)
                .Select(m => new MedalCountByCountryDto(m.Gold, m.Country))
                .ToList();

            var silverMedals = medalCounts
                .OrderByDescending(m => m.Silver)
                .Select(m => new MedalCountByCountryDto(m.Silver, m.Country))
                .ToList();

            var bronzeMedals = medalCounts
                .OrderByDescending(m => m.Bronze)
                .Select(m => new MedalCountByCountryDto(m.Bronze, m.Country))
                .ToList();

            return new GetTableResponse
            {
                Gold = goldMedals,
                Silver = silverMedals,
                Bronze = bronzeMedals
            };
        }
    }
}
