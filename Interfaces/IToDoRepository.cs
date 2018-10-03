using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Core;

    namespace ToDoApp.Domain.Interfaces
{
    public interface IToDoRepository : IDisposable
    {
        IEnumerable<ToDo> GetToDoList();
        IEnumerable<ToDo> GetToDoUserList(int id);
        int GetUserId(string name);
        ToDo GetToDo(int id);
        void Create(ToDo item);
        void Update(ToDo item);
        void Delete(int id);
        bool ToDoExist(int todoId);
        string ToDoDo (int todoId);
        void Save();
    }
}
