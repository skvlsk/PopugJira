using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PopugJira.TaskTracker.Features.PopugTask.Commands;

namespace PopugJira.TaskTracker.Features.PopugTask
{
    [Route("api/popug-task")]
    public class PopugTaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public PopugTaskController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(string id)
        {
            var result = await _mediator.Send(new Queries.GetPopugTask.Query {Id = id});
            
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var result = await _mediator.Send(new Queries.GetAllPopugTasks.Query());

            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreatePopugTask.Command request)
        {
            var result = await _mediator.Send(request);
            
            return new JsonResult(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdatePopugTask.Command request)
        {
            var result = await _mediator.Send(request);
            
            return new JsonResult(result);
        }

        [HttpPatch("{id}/state")]
        public async Task<IActionResult> ChangeState([FromBody] ChangeStatePopugTask.Command request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}