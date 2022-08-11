using TasksApi.Models;

namespace TasksApi.Services
{
    public interface IFileService
    {
        Task<List<UploadResult>> GetFiles();
        Task<UploadResult> GetFile(int id);
        System.Threading.Tasks.Task Delete(int id);
    }
}
