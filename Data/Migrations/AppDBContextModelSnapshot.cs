﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ToDoApp.Infrastructure.Data;

namespace Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ToDoApp.Domain.Core.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ListOwner");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("ToDoApp.Domain.Core.Tag", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ToDoApp.Domain.Core.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Check");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DoDate");

                    b.Property<int?>("ListId");

                    b.Property<string>("Name");

                    b.Property<int>("TodoListId");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("ToDoApp.Domain.Core.TodoTag", b =>
                {
                    b.Property<int>("TodoId");

                    b.Property<int>("TagId");

                    b.HasKey("TodoId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TodoTag");
                });

            modelBuilder.Entity("ToDoApp.Domain.Core.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ToDoApp.Domain.Core.UserList", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ListId");

                    b.HasKey("UserId", "ListId");

                    b.HasIndex("ListId");

                    b.ToTable("UserList");
                });

            modelBuilder.Entity("ToDoApp.Domain.Core.Todo", b =>
                {
                    b.HasOne("ToDoApp.Domain.Core.List", "List")
                        .WithMany("Todos")
                        .HasForeignKey("ListId");
                });

            modelBuilder.Entity("ToDoApp.Domain.Core.TodoTag", b =>
                {
                    b.HasOne("ToDoApp.Domain.Core.Tag", "Tag")
                        .WithMany("TodoTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ToDoApp.Domain.Core.Todo", "Todo")
                        .WithMany("TodoTags")
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ToDoApp.Domain.Core.UserList", b =>
                {
                    b.HasOne("ToDoApp.Domain.Core.List", "List")
                        .WithMany("UserLists")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ToDoApp.Domain.Core.User", "User")
                        .WithMany("UserLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
