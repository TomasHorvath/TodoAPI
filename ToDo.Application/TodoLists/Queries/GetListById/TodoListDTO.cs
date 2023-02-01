using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.TodoLists.Queries.GetListById
{

    public record TodoListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TodoItemDTO> Items { get; set; }
    }

    public class TodoItemDTO
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Priority { get; set; }
    }
}
