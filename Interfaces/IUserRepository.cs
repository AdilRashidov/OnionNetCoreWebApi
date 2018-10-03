using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Core;


namespace ToDoApp.Domain.Interfaces
{
    public interface IUserRepository:IDisposable
    {
        void Create(User item);
        IEnumerable<User> GetUserList();
        void Save();    
        bool UserExist(User user);
        void Delete(int id);
    }
}
