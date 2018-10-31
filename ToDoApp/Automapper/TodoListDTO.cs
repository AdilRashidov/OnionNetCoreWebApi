using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Automapper
{
    public class TodoListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ListOwner { get; set;}
    }
}
