namespace TaskManagementApplication.DTOs
{
    public record UpdateTaskDto(
     string Title,
     string Description,
     DateTime DueDate,
     string Priority,
     string Status
 );
}
