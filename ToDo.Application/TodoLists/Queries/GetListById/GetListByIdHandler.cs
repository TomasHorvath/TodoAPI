using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Common.Interfaces;

namespace Todo.Application.TodoLists.Queries.GetListById
{
    public record GetListById : IRequest<TodoListDTO>
    {
        public int Id { get; set; } 
    }

    public class GetListByIdHandler : IRequestHandler<GetListById, TodoListDTO>
    {
        private readonly IRepository<Domain.Entities.TodoList> _repository;
        private readonly ILogger<GetListByIdHandler> _logger;

        public GetListByIdHandler(IRepository<Domain.Entities.TodoList> repository, ILogger<GetListByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<TodoListDTO> Handle(GetListById request, CancellationToken cancellationToken)
        {
            // automapper 

            var todos = _repository.Get(request.Id);

            return new TodoListDTO()
            {
                Id = todos.Id,
                Name = todos.Name,
                Items = todos.Items.Select(e=> new TodoItemDTO() { Id = e.Id , Name =e.Name , Priority = e.Priority })
            };
        }
    }

}
