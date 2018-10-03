using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Domain.Core
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Tags { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public bool Check { get; set; }
        //[Required]
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
