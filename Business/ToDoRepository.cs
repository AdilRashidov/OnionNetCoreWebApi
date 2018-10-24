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
    public class ToDoRepository : IToDoRepository
    {
        private ToDoContext _repository;
        public ToDoRepository(ToDoContext context)
        {
            _repository = context;
        }
        public IEnumerable<ToDo> GetToDoList()
        {
            return _repository.ToDos.ToList();
        }
        public int GetUserId(string name)
        {
            int ID;
            var lul = _repository.Users.Where(x => x.Email == name).SingleOrDefault();//current user
            return ID = lul.Id;
        }
        public IEnumerable<ToDo> GetToDoUserList(int id)
        {
            //int id = GetUserById(name);
            var todo = _repository.ToDos.Where(x => x.UserId == id);
            return todo;
        }
        public ToDo GetToDo(int id)
        {
            return _repository.ToDos.FirstOrDefault(x=>x.Id==id);
        }
        public void Create(ToDo todo)
        { 
            _repository.ToDos.Add(todo);
        }
        public void Update(ToDo todo)
        {
            _repository.Entry(todo).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            ToDo todo = _repository.ToDos.Find(id);
            if (todo != null)
                _repository.ToDos.Remove(todo);
        }
        public bool ToDoExist(int todoId)                       //проверка наличия записи
        {
            bool lul = _repository.ToDos.Any(x => x.Id == todoId); //по айди
            return lul;                                        //есть ли запись
        }
        public void Save()
        {
            _repository.SaveChanges();
        }
        public string ToDoDo(int todoId)
        {
            var tododo = _repository.ToDos.Where(x => x.Id == todoId).SingleOrDefault();
            if (tododo.Check == true) { tododo.Check = false; _repository.Entry(tododo).State = EntityState.Modified; return "Zadanie not vypolneno"; }
            else { tododo.Check = true; _repository.Entry(tododo).State = EntityState.Modified; return "Zadanie done";  }
        }

        
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
