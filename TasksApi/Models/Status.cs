using System.Text.Json.Serialization;

namespace TasksApi.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Task>? Tasks { get; set; }
    }
}
