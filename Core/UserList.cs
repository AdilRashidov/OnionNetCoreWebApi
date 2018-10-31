
namespace ToDoApp.Domain.Core
{
    public class UserList
    {
        public int UserId { get; set; }
        public  User User{ get; set; }

        public int ListId { get; set; }
        public List List { get; set; }
    }
}
