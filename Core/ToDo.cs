using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Core
{
    public class Todo
    {   
        public Todo()
        {
            this.Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DoDate{ get; set;}  
        public bool Check { get; set; }
        public TodoList TodoList {get ; set;}
        public ICollection<Tag> Tags{get;set;}

    }
}
