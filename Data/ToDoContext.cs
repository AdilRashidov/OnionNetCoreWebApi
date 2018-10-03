using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Core;

namespace ToDoApp.Infrastructure.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<User> Users { get; set; }
      //  public ToDoContext() { }
        public ToDoContext(DbContextOptions<ToDoContext> options)    : base(options)       { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=todoappdb;Trusted_Connection=True;");
        }

    }
}
