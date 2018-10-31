using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Infrastructure.Business
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IListRepository Lists { get; }
        ITodoRepository Todos { get; }
        ITagsRepository Tags { get;}
        int SaveChanges();
        
    }
}