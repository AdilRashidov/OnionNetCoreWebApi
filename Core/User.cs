﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ToDoApp.Domain.Core
{
    public class User
    {
        public User()
        {
            this.UserLists = new List<UserList>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<UserList> UserLists { get; set; }

    }

}
