using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Common.Interfaces;
using Todo.Application.TodoLists.Queries.GetAllLists;
using Todo.Domain.Entities;

namespace Todo.Application.TodoLists.Commands.CreateTodoListCommand
{
    public record CreateTodoListCommand : IRequest<int>
    {
        public string Title { get; init; }
    }

    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
    {
        private readonly IRepository<Domain.Entities.TodoList> _repository;
        private readonly ILogger<CreateTodoListCommandHandler> _logger;

        public CreateTodoListCommandHandler(IRepository<TodoList> repository, ILogger<CreateTodoListCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var todoList = new TodoList() { Name = request.Title, Id = 1 };
            
            _repository.Insert(todoList);

            return todoList.Id;
        }
    }
}
