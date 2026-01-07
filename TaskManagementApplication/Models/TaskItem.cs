namespace TaskManagementApplication.Models
{
  
        public class TaskItem
        {
            public int TaskId { get; set; }
            public int UserId { get; set; }

            public string Title { get; set; } = string.Empty;
            public string? Description { get; set; }

            public DateTime DueDate { get; set; }

            public string Priority { get; set; } = "Low";
            // Low | Medium | High

            public string Status { get; set; } = "Pending";
            // Pending | Completed

            public DateTime CreatedAt { get; set; }
        }


}
