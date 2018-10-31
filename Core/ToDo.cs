using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Core
{
    public class Todo
    {   
        public Todo()
        {
            this.TodoTags = new List<TodoTag>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DoDate{ get; set;}  
        public bool Check { get; set; }
        public int TodoListId { get; set; }
        public List List {get ; set;}
        public ICollection<TodoTag> TodoTags {get;set;}

    }
}
