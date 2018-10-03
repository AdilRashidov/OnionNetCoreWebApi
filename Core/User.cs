using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Domain.Core
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
        public List<ToDo> ToDos { get; set; }
    }

    public class LoginVm
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
