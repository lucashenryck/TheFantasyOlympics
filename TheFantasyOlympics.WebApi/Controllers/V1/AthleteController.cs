using MediatR;
using Microsoft.AspNetCore.Mvc;
using TheFantasyOlympics.Application.UseCases.Athlete.Edit;
using TheFantasyOlympics.Application.UseCases.Athlete.ListAll;
using TheFantasyOlympics.Application.UseCases.Athlete.Register;

namespace TheFantasyOlympics.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest registerRequest, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(registerRequest, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EditResponse>> Edit(int id, EditRequest editRequest, CancellationToken cancellationToken)
        {
            if (id != editRequest.Id)
                return BadRequest();

            var response = await _mediator.Send(editRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListAllResponse>>> ListAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ListAllResponse(), cancellationToken);
            return Ok(response);
        }
    }
}
