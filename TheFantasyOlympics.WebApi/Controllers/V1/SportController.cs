using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TheFantasyOlympics.Application.UseCases.Sport.Delete;
using TheFantasyOlympics.Application.UseCases.Sport.Edit;
using TheFantasyOlympics.Application.UseCases.Sport.Register;

namespace TheFantasyOlympics.WebApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class SportController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterSportRequest registerRequest, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(registerRequest, cancellationToken);
            return Ok(response);
        }

        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> Edit(int id, EditSportRequest editRequest, CancellationToken cancellationToken)
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

            var deleteRequest = new DeleteSportRequest(id);
            var response = await _mediator.Send(deleteRequest, cancellationToken);
            return Ok(response);
        }
    }
}
