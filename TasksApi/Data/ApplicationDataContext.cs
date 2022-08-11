using Microsoft.EntityFrameworkCore;
using TasksApi.Models;
using Task = TasksApi.Models.Task;

namespace TasksApi.Data
{
    public class ApplicationDataContext:DbContext
    {
        public ApplicationDataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    Name = "В работе"
                },
                new Status
                {
                    Id = 2,
                    Name = "На тестировании"
                },
                new Status
                {
                    Id = 3,
                    Name = "Готово"
                }

            );
            modelBuilder.Entity<Task>().HasData(
                    new Task
                    {
                        Id = 1,
                        Name = "Баг номер 1",
                        StatusId = 1
                    },
                    new Task
                    {
                        Id = 2,
                        Name = "Баг номер 2",
                        Date = DateTime.Now,
                        StatusId = 1
                    }
                );
        }
        public DbSet<Task> Tasks => Set<Task>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<UploadResult> UploadResults => Set<UploadResult>();
    }
}
