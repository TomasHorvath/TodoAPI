using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Enums;

namespace Todo.Application.TodoItems.Commands.UpdateTodoCommand
{
    public class TodoItemDTO
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Priority { get; set; }
        public ToDoStatus Status { get;  set; }
    }
}
