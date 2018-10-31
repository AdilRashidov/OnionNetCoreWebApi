using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Core;


namespace ToDoApp.Domain.Interfaces
{
    public interface IListRepository:IRepository<List>
    {
        IEnumerable<List> GetTodoListForUser(int id);
    }
}
