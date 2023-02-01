using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.TodoItems.Commands.CreateTodoCommand
{
    public record CreateTodoCommand : IRequest<int>
    {
        public int TodoListId { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
    }

    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, int>
    {
        private readonly IRepository<Domain.Entities.TodoList> _repository;
        private readonly ILogger<CreateTodoCommandHandler> _logger;

        public CreateTodoCommandHandler(IRepository<TodoList> repository, ILogger<CreateTodoCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todoList = _repository.Get(request.TodoListId);

            if (todoList is null)
                throw new Exception("Not found");

            var id = !todoList.Items.Any() ? 1 : todoList.Items.Max(e=>e.Id) + 1;

            todoList.Items.Add(new ToDoItem() { Id = id , Name = request.Title, Priority = request.Priority });

            _repository.Update(todoList);

            return todoList.Id;
        }
    }
}
