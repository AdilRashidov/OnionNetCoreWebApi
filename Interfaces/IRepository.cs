using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Core;

    namespace ToDoApp.Domain.Interfaces
{  
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}