namespace TaskManagementApplication.DTOs
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } = string.Empty;   // Low/Medium/High
        public string Status { get; set; } = string.Empty;     // Pending/Completed
        public DateTime CreatedAt { get; set; }
    }
}
