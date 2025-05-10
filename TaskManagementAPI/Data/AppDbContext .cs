using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using TaskManagementAPI.Model;

namespace TaskManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin123", Role = UserRole.Admin },
                new User { Id = 2, Username = "john", Password = "john123", Role = UserRole.User },
                new User { Id = 3, Username = "jane", Password = "jane123", Role = UserRole.User }
            );

            // Seed Tasks
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Setup project", Description = "Create .NET API project", DueDate = DateTime.UtcNow.AddDays(3), AssignedToId = 2 },
                new TaskItem { Id = 2, Title = "Design DB", Description = "Prepare ER diagram", DueDate = DateTime.UtcNow.AddDays(5), AssignedToId = 3 },
                new TaskItem { Id = 3, Title = "Implement Auth", Description = "Add JWT authentication", DueDate = DateTime.UtcNow.AddDays(7), AssignedToId = 2 }
            );

            // Seed TaskComments
            modelBuilder.Entity<TaskComment>().HasData(
                new TaskComment { Id = 1, Content = "Kick-off done!", CreatedAt = DateTime.UtcNow, TaskId = 1, UserId = 2 },
                new TaskComment { Id = 2, Content = "Schema shared.", CreatedAt = DateTime.UtcNow, TaskId = 2, UserId = 3 },
                new TaskComment { Id = 3, Content = "Auth module WIP.", CreatedAt = DateTime.UtcNow, TaskId = 3, UserId = 2 }
            );
        }

    }
}
