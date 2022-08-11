namespace TasksApi.Models
{
    public class UploadResult
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string StoredFileName { get; set; } = string.Empty;

        public int TaskId { get; set; }
        public Task? Task { get; set; }
    }
}
