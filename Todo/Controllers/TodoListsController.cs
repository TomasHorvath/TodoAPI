using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.TodoItems.Commands.CreateTodoCommand;
using Todo.Application.TodoLists.Commands.CreateTodoListCommand;
using Todo.Application.TodoLists.Queries.GetAllLists;
using Todo.Application.TodoLists.Queries.GetListById;

namespace ToDo.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListsController : ApiControllerBase
    {
        private readonly ILogger<TodoListsController> _logger;

        public TodoListsController(ILogger<TodoListsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetListById() {  Id = id});

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetAllTodoLists());

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
        {
            return await Mediator.Send(command);
        }

      
    }
}