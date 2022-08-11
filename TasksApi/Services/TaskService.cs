using Microsoft.EntityFrameworkCore;
using TasksApi.Data;

namespace TasksApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDataContext _db;

        public TaskService(ApplicationDataContext db)
        {
            _db = db;
        }
        public async System.Threading.Tasks.Task Create(Models.Task task)
        {
            var dbTask = await _db.Tasks.FirstAsync(t => t.Name == task.Name);
            if (dbTask != null)
                throw new Exception($"Задача \'{task.Name}\' уже существует");
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
                throw new Exception("Нет такой задачи");
            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
        }

        public async Task<Models.Task> GetTask(int id)
        {
            //var task = await _db.Tasks.Include(t => t.Status).FirstOrDefaultAsync(t => t.Id == id);
            var task = await _db.Tasks.Include(t => t.Status).FirstOrDefaultAsync(t=>t.Id == id);
            if (task == null)
                throw new Exception("Нет такой задачи");
            return task;
        }

        public async Task<List<Models.Task>> GetTasks()
        {
            var tasks = await _db.Tasks
                .Include(t=>t.Status)
                .ToListAsync();
            return tasks;
        }

        public async System.Threading.Tasks.Task Update(Models.Task task)
        {
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
        }
    }
}
