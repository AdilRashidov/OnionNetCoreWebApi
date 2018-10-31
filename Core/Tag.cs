using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Core
{
    public class Tag
    {   
        public Tag ()
        {
            this.TodoTags = new List<TodoTag>();
        }
        public int? Id { get; set; }
        public string Name { get; set; }
        public ICollection<TodoTag> TodoTags { get; set; }  
    }
}