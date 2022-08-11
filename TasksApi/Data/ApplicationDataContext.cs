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
                },
                new Status
                {
                    Id = 4,
                    Name = "Отмена"
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
                        StatusId = 2
                    },
                    new Task
                    {
                        Id = 3,
                        Name = "Баг номер 3",
                        Date = DateTime.Now,
                        StatusId = 3
                    },
                    new Task
                    {
                        Id = 4,
                        Name = "Баг номер 4",
                        Date = DateTime.Now,
                        StatusId = 4
                    },
                    new Task
                    {
                        Id = 5,
                        Name = "Баг номер 5",
                        Date = DateTime.Now,
                        StatusId = 1
                    },
                    new Task
                    {
                        Id = 6,
                        Name = "Баг номер 6",
                        Date = DateTime.Now,
                        StatusId = 2
                    }
                );
        }
        public DbSet<Task> Tasks => Set<Task>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<UploadResult> UploadResults => Set<UploadResult>();
    }
}
