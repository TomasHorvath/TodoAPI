using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;
using Todo.Domain.Enums;

namespace Todo.Application.TodoItems.Commands.UpdateTodoCommand
{
    public record UpdateTodoCommand : IRequest<TodoItemDTO>
    {
        public int TodoListId { get; set; }
        public int TodoItemId { get; set; }
        public int Priority { get; set; }
        public ToDoStatus ToDoStatus { get; set; }
    }

    public class CreateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, TodoItemDTO>
    {
        private readonly IRepository<Domain.Entities.TodoList> _repository;
        private readonly ILogger<CreateTodoCommandHandler> _logger;

        public CreateTodoCommandHandler(IRepository<TodoList> repository, ILogger<CreateTodoCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<TodoItemDTO> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todoList = _repository.Get(request.TodoListId);

            if (todoList is null)
                throw new Exception("Not found");

            var todoItem = todoList.Items.FirstOrDefault(e => e.Id == request.TodoItemId);
            
            todoItem.ToDOStatus = request.ToDoStatus;
            todoItem.Priority = request.Priority;

            _repository.Update(todoList);

            return new TodoItemDTO { Id = todoItem.Id, Name = todoItem.Name, Priority = todoItem.Priority, Status = todoItem.ToDOStatus };
        }
    }
}
