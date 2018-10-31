using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Core;

namespace ToDoApp.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TodoList> ToDoLists { get; set; }      
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)    : base(options)       { }
        
    }
}
