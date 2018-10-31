using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Infrastructure.Business
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ITodoListRepository TodoLists { get; }
        ITodoRepository Todos { get; }
        ITagsRepository Tags { get;}
        int SaveChanges();
        
    }
}