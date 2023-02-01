using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Common.Interfaces;
using Todo.Application.TodoLists.Queries.GetAllLists;
using Todo.Domain.Entities;

namespace Todo.Application.TodoItems.Commands.UpdateTodoCommand
{


    public class UpdateTodoListValidator : AbstractValidator<UpdateTodoCommand>
    {
        private readonly IRepository<Domain.Entities.TodoList> _repository;

        public UpdateTodoListValidator(IRepository<TodoList> repository)
        {
            _repository = repository;

         
        }



    }

}
