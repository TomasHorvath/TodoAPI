using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Common.Interfaces;

namespace Todo.Application.TodoLists.Queries.GetAllLists
{
    public record GetAllTodoLists : IRequest<TodosDTO>
    {
    }

    public class GetListByIdHandler : IRequestHandler<GetAllTodoLists, TodosDTO>
    {
        private readonly IRepository<Domain.Entities.TodoList> _repository;
        private readonly ILogger<GetListByIdHandler> _logger;

        public GetListByIdHandler(IRepository<Domain.Entities.TodoList> repository, ILogger<GetListByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<TodosDTO> Handle(GetAllTodoLists request, CancellationToken cancellationToken)
        {
            // automapper 

            var todos = _repository.GetAll().Select(todos => new TodoListDTO() { Id = todos.Id, Name = todos.Name });

            return new TodosDTO() { Lists = todos };
        }
    }

}
