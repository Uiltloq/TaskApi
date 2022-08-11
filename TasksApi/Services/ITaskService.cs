namespace TasksApi.Services
{
    public interface ITaskService
    {
        Task<List<TasksApi.Models.Task>> GetTasks();
        Task<List<TasksApi.Models.Task>> GetTasksLimit(int id);
        Task<Models.Task> GetTask(int value);
        System.Threading.Tasks.Task Create(Models.Task newTask);
        System.Threading.Tasks.Task Update(Models.Task taskDto);
        System.Threading.Tasks.Task Delete(int id);
        System.Threading.Tasks.Task UploadFile(IFormFile file, int taskId);
    }
}
