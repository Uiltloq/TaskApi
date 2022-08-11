namespace TasksApi.Dto
{
    public class UpdateTaskDto
    {
        public DateTime Date { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StatusId { get; set; }
    }
}
