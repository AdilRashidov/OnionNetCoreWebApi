﻿using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Core;
using ToDoApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.SqlClient;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Business
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(DbContext context) : base(context)
        {}
        public IEnumerable<Todo> GetTodos()
        {
            IEnumerable<Todo>fix=null;
            return fix;
        }
        private AppDBContext  _appContext => (AppDBContext) _context;
    }
}
