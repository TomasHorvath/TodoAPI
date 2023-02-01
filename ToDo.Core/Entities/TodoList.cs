using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities
{
    public class TodoList : Common.BaseEntity
    {
        public TodoList()
        {
            Items = new List<ToDoItem>();
        }
        public string Name { get; set; }

        public IList<ToDoItem> Items { get; set; }
    }
}
