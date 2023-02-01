using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.TodoLists.Queries.GetAllLists
{
    public record TodosDTO
    {
        public IEnumerable<TodoListDTO> Lists { get; set; } 
    }

    public record TodoListDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        
    }
}
