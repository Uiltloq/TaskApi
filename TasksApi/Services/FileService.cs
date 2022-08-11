using Microsoft.EntityFrameworkCore;
using TasksApi.Data;
using TasksApi.Models;

namespace TasksApi.Services
{
    public class FileService : IFileService
    {
        private readonly ApplicationDataContext _db;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public FileService(ApplicationDataContext db, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var file = await GetFile(id);
            _db.UploadResults.Remove(file);
            var pathFile = Path.Combine(_hostingEnvironment.ContentRootPath, file.StoredFileName);
            File.Delete(pathFile);
            await _db.SaveChangesAsync();
        }

        public async Task<UploadResult> GetFile(int id)
        {
            var file = await _db.UploadResults.FindAsync(id);
            if (file == null)
                throw new Exception("Нет такакого файла");
            return file;
        }

        public async Task<List<UploadResult>> GetFiles()
        {
            return await _db.UploadResults.ToListAsync();
        }
    }
}
