using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TheFantasyOlympics.Application.UseCases.Modality.ListByFilter;
using TheFantasyOlympics.Application.UseCases.Modality.Register;

namespace TheFantasyOlympics.WebApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ModalityController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterModalityRequest registerRequest, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(registerRequest, cancellationToken);
            return Ok(response);
        }

        [HttpGet("ListByFilter")]
        public async Task<ActionResult<List<ListByFilterResponse>>> ListByFilter([Required] int sportId, string? type, string? genre, CancellationToken cancellationToken)
        {
            var listByFilterRequest = new ListByFilterRequest(sportId, type, genre);
            var response = await _mediator.Send(listByFilterRequest, cancellationToken);
            return Ok(response);
        }
    }
}
