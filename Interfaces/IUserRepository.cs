using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Core;


namespace ToDoApp.Domain.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
         int GetUserId(string email);
    }
}
