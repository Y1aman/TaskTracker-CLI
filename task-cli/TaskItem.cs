using System;



namespace task_cli
{
    public enum TaskStatus
    {
        Todo,
        InProgress,
        Done
    }
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}