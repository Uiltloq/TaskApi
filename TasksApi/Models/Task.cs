namespace TasksApi.Models
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public List<UploadResult> UploadResults { get; set; } = new List<UploadResult>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Task() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Task(DateTime date, string name, int statusId, Status status)
        {
            Date = date;
            Name = name;
            StatusId = statusId;
            Status = status;
        }
    }
}
