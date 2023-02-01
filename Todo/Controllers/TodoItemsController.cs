using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.TodoItems.Commands.CreateTodoCommand;
using Todo.Application.TodoItems.Commands.DeleteTodoCommand;
using Todo.Application.TodoItems.Commands.UpdateTodoCommand;

namespace ToDo.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ApiControllerBase
    {

        private readonly ILogger<TodoItemsController> _logger;
        private readonly IMediator _mediator;
        public TodoItemsController(ILogger<TodoItemsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePost(CreateTodoCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<TodoItemDTO>> UpdateToDoItem(UpdateTodoCommand command)
        {
             return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteToDoItem(DeleteTodoCommand command)
        {
             await Mediator.Send(command);

            return NoContent();
        }
    }
}