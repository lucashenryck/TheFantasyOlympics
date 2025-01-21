using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TheFantasyOlympics.Application.UseCases.Athlete.Delete;
using TheFantasyOlympics.Application.UseCases.Athlete.Edit;
using TheFantasyOlympics.Application.UseCases.Athlete.FindById;
using TheFantasyOlympics.Application.UseCases.Athlete.ListAll;
using TheFantasyOlympics.Application.UseCases.Athlete.ListByCountry;
using TheFantasyOlympics.Application.UseCases.Athlete.ListBySport;
using TheFantasyOlympics.Application.UseCases.Athlete.ListByTeam;
using TheFantasyOlympics.Application.UseCases.Athlete.Register;

namespace TheFantasyOlympics.WebApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AthleteController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterAthleteRequest registerRequest, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(registerRequest, cancellationToken);
            return Ok(response);
        }

        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> Edit(int id, EditAthleteRequest editRequest, CancellationToken cancellationToken)
        {
            if (id != editRequest.Id || id <= 0 || editRequest.Id <= 0)
                return BadRequest();

            var response = await _mediator.Send(editRequest, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                return BadRequest("Id needs to be valid.");

            var deleteRequest = new DeleteAthleteRequest(id);
            var response = await _mediator.Send(deleteRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("ListAll")]
        public async Task<ActionResult<List<ListAllAthletesResponse>>> ListAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ListAllAthletesRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<FindByIdResponse>> FindById(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                return BadRequest("Id needs to be valid.");

            var findByIdRequest = new FindByIdRequest(id);
            var response = await _mediator.Send(findByIdRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("ListByCountry/{countryName}")]
        public async Task<ActionResult<List<ListAthletesByCountryResponse>>> ListByCountry(string countryName, CancellationToken cancellationToken)
        {
            var listByCountryRequest = new ListAthletesByCountryRequest(countryName);
            var response = await _mediator.Send(listByCountryRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("ListBySport/{sportId}")]
        public async Task<ActionResult<List<ListAthletesBySportResponse>>> ListBySport(int sportId, CancellationToken cancellationToken)
        {
            if (sportId <= 0)
                return BadRequest("Sport Id needs to be valid.");

            var listBySportRequest = new ListAthletesBySportRequest(sportId);
            var response = await _mediator.Send(listBySportRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("ListByTeam/{teamName}")]
        public async Task<ActionResult<List<ListByTeamResponse>>> ListByTeam(string teamName, CancellationToken cancellationToken)
        {
            var listByTeamRequest = new ListByTeamRequest(teamName);
            var response = await _mediator.Send(listByTeamRequest, cancellationToken);
            return Ok(response);
        }
    }
}
