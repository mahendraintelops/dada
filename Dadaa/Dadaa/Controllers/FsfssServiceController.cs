using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.FsfssService;
using Application.Queries.FsfssService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FsfssServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FsfssServiceController> _logger;
        public FsfssServiceController(IMediator mediator, ILogger<FsfssServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreateFsfss")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateFsfss([FromBody] CreateFsfssCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        
        [HttpGet(Name = "GetAllFsfsses")]
        [ProducesResponseType(typeof(IEnumerable<List<FsfssResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<FsfssResponse>>> GetAllFsfsses(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllFsfssesQuery(), cancellationToken);
            return Ok(response);
        }
        

        

        
        [HttpPut(Name = "UpdateFsfss")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateFsfss([FromBody] UpdateFsfssCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        

        
    }
}
