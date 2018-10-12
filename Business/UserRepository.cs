using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ToDoApp.Domain.Core;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Business
{
    public class UserRepository:IUserRepository
    {
        private ToDoContext _repository;

        public UserRepository(ToDoContext context)
        {
            _repository = context;
        }
        public IEnumerable<User> GetUserList()
        {
            return _repository.Users.ToList();
        }
        public void Create(User user)
        {
            user.Role = "user";
            _repository.Users.Add(user);
        }
        public void Delete(int id)
        {
            User user = _repository.Users.Find(id);
            if (user != null)
                _repository.Users.Remove(user);
        }
        public bool UserExist(User user)      //проверка, есть ли пользователь
        {
            string email = user.Email;
            bool lul =_repository.Users.Any(x=>x.Email==email);
            return lul;

        }
        public void Save()
        {
            _repository.SaveChanges();
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
