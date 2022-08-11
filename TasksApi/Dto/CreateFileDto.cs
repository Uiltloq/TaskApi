namespace TasksApi.Dto
{
    public class CreateFileDto
    {
        public string FileName { get; set; } = string.Empty;
        public string StoredFileName { get; set; } = string.Empty;
        public int TaskId { get; set; }
    }
}
