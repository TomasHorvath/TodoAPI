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

namespace Todo.Application.TodoItems.Commands.CreateTodoCommand
{


    public class CreateTodoListValidator : AbstractValidator<CreateTodoCommand>
    {
        private readonly IRepository<Domain.Entities.TodoList> _repository;

        public CreateTodoListValidator(IRepository<TodoList> repository)
        {
            _repository = repository;

            RuleFor(x => x.Title)
                .MinimumLength(3).WithMessage(".... malo znaku...");
 

            RuleFor(x=>x)
                .Must(BeUniqueTitle).WithMessage(".... musi byt unikatni...");
        }

        public  bool BeUniqueTitle(CreateTodoCommand command)
        {
            
            return  _repository.Get(command.TodoListId).Items.All(l => l.Name != command.Title);
        }

    }

}
