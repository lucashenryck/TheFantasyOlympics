using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TheFantasyOlympics.Application.UseCases.Medal.FindModalityPodium;
using TheFantasyOlympics.Application.UseCases.Medal.GetTable;
using TheFantasyOlympics.Application.UseCases.Medal.ListByCountry;
using TheFantasyOlympics.Application.UseCases.Medal.ListBySport;
using TheFantasyOlympics.Application.UseCases.Medal.RegisterModalityPodium;

namespace TheFantasyOlympics.WebApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class MedalController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("ListByCountry/{countryName}")]
        public async Task<ActionResult<List<ListMedalsByCountryResponse>>> ListByCountry(string countryName, CancellationToken cancellationToken)
        {
            var listByCountryRequest = new ListByCountryRequest(countryName);
            var response = await _mediator.Send(listByCountryRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("ListBySport/{sportId}")]
        public async Task<ActionResult<List<ListMedalsBySportResponse>>> ListBySport(int sportId, CancellationToken cancellationToken)
        {
            if (sportId <= 0)
                return BadRequest("Sport Id needs to be valid.");

            var listBySportRequest = new ListBySportRequest(sportId);
            var response = await _mediator.Send(listBySportRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("FindModalityPodium/{modalityId}")]
        public async Task<ActionResult<List<FindModalityPodiumResponse>>> FindModalityPodium(int modalityId, CancellationToken cancellationToken)
        {
            if (modalityId <= 0)
                return BadRequest("Modality Id needs to be valid.");

            var findModalityPodiumRequest = new FindModalityPodiumRequest(modalityId);
            var response = await _mediator.Send(findModalityPodiumRequest, cancellationToken);
            return Ok(response);
        }

        [HttpPost("RegisterModalityPodium")]
        public async Task<ActionResult> RegisterModalityPodium(RegisterModalityPodiumRequest registerRequest, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(registerRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("GetTable")]
        public async Task<ActionResult<GetTableResponse>> GetTable(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetTableRequest(), cancellationToken);
            return Ok(response);
        }
    }
}
