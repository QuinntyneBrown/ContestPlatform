using System.Net;
using System.Threading.Tasks;
using ContestPlatform.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContestPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContestController
    {
        private readonly IMediator _mediator;

        public ContestController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{contestId}", Name = "GetContestByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetContestById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetContestById.Response>> GetById([FromRoute]GetContestById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Contest == null)
            {
                return new NotFoundObjectResult(request.ContestId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetContestsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetContests.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetContests.Response>> Get()
            => await _mediator.Send(new GetContests.Request());
        
        [HttpPost(Name = "CreateContestRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateContest.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateContest.Response>> Create([FromBody]CreateContest.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetContestsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetContestsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetContestsPage.Response>> Page([FromRoute]GetContestsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateContestRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateContest.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateContest.Response>> Update([FromBody]UpdateContest.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{contestId}", Name = "RemoveContestRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveContest.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveContest.Response>> Remove([FromRoute]RemoveContest.Request request)
            => await _mediator.Send(request);
        
    }
}
