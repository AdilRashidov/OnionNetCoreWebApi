using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Infrastructure.Automapper
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
        public string Desc { get; set; }
        public bool Check { get; set; }
    }
}
