using System;
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
    public class ListRepository : Repository<List>, IListRepository
    {
        public ListRepository(DbContext context) : base(context)
        {}
        
        public IEnumerable<List> GetTodoListForUser(int id)
        {
            var TodoList = _appContext.Lists.Where(x=>x.ListOwner==id);
            return TodoList;
        }
        private AppDBContext  _appContext => (AppDBContext) _context;
    }
}
