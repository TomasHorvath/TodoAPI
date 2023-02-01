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

namespace Todo.Application.TodoLists.Commands.CreateTodoListCommand
{


    public class CreateTodoListValidator : AbstractValidator<CreateTodoListCommand>
    {
        private readonly IRepository<Domain.Entities.TodoList> _repository;

        public CreateTodoListValidator(IRepository<TodoList> repository)
        {
            _repository = repository;

            RuleFor(x => x.Title)
                .MinimumLength(3).WithMessage(".... malo znaku...")
                .Must(UniqueName).WithMessage(".... musi byt unikatni...");
        }

        public  bool UniqueName(string title)
        {
            return  _repository.GetAll().All(l => l.Name != title);
        }

    }

}
