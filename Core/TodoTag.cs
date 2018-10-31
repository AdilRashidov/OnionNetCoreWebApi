using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Core
{
    public class TodoTag
    {
        public int TodoId { get; set; }
        public Todo Todo { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
