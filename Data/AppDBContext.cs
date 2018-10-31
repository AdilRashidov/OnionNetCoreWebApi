using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Core;


namespace ToDoApp.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Tag> Tags { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many User table and List table
            modelBuilder.Entity<UserList>()
                .HasKey(t => new { t.UserId, t.ListId });

            modelBuilder.Entity<UserList>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserLists)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserList>()
                .HasOne(sc => sc.List)
                .WithMany(s => s.UserLists)
                .HasForeignKey(sc => sc.ListId);
            //many to many Todo table and Tags table
            modelBuilder.Entity<TodoTag>()
                 .HasKey(t => new { t.TodoId, t.TagId });

            modelBuilder.Entity<TodoTag>()
                .HasOne(sc => sc.Todo)
                .WithMany(s => s.TodoTags)
                .HasForeignKey(sc => sc.TodoId);

            modelBuilder.Entity<TodoTag>()
                .HasOne(sc => sc.Tag)
                .WithMany(s => s.TodoTags)
                .HasForeignKey(sc => sc.TagId);
        }

    }
}
