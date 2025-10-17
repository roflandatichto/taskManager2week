namespace taskmanager.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}