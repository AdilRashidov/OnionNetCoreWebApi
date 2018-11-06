using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Core;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Business
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {}
        public int GetUserId(string email)
        {
            return 0;
            
        }
        private AppDBContext  _appContext => (AppDBContext) _context;
    }
}
