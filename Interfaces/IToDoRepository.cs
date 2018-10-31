using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Core;

    namespace ToDoApp.Domain.Interfaces
{
    public interface ITodoRepository:IRepository<Todo>
    {
         IEnumerable<Todo> GetTodos() ;

    }
}
