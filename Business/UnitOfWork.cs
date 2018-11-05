using ToDoApp.Infrastructure.Data;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Infrastructure.Business
{
    public class UnitOfWork: IUnitOfWork
    {
        readonly AppDBContext _context;

        IUserRepository _users;
        IListRepository _lists;
        ITodoRepository _todos;
        ITagsRepository _tags;
    
        public UnitOfWork(AppDBContext context)
        {
            _context=context;
        }
    
        public IUserRepository Users
        {
            get
            {
                if(_users==null)
                _users = new UserRepository(_context);
                return _users;
            }
        }

        public IListRepository Lists
        {
            get
            {
                if(_lists==null)
                _lists = new ListRepository(_context);
                return _lists;
            }
        }

        public ITodoRepository Todos
        {
            get
            {
                if(_todos==null)
                _todos = new TodoRepository(_context);
                return _todos;
            }
        }

        public ITagsRepository Tags
        {
            get
            {
                if(_tags==null)
                _tags = new TagsRepository(_context);
                return _tags;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        
    
    
    }
}
