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

namespace Todo.Application.TodoItems.Commands.DeleteTodoCommand
{
    public record DeleteTodoCommand : IRequest
    {
        public int TodoListId { get; set; }
        public int TodoItemId { get; set; }

    }

    public class CreateTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
    {
        private readonly IRepository<Domain.Entities.TodoList> _repository;
        private readonly ILogger<CreateTodoCommandHandler> _logger;

        public CreateTodoCommandHandler(IRepository<TodoList> repository, ILogger<CreateTodoCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

      
        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todoList = _repository.Get(request.TodoListId);

            if (todoList is null)
                throw new Exception("Not found");

            var todoItem = todoList.Items.FirstOrDefault(e => e.Id == request.TodoItemId);

            if (todoItem is not null && todoItem.ToDOStatus == ToDoStatus.Completed)
                todoList.Items.Remove(todoItem);
            
            return Unit.Value;
        }
    }
}
