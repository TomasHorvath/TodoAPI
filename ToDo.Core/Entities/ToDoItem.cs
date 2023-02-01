using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class ToDoItem : Common.BaseEntity
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public ToDoStatus ToDOStatus { get; set; }
    }
}
