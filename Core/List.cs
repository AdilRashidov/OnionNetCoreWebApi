using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Core
{
    public class List
    {
        public List()
        {
            this.UserLists = new List<UserList>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ListOwner { get; set; }
        public ICollection<UserList> UserLists { get; set; }

        public ICollection<Todo> Todos { get; set; }

    }
}
