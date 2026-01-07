using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementApplication.DTOs
{
    public record CreateTaskDto(
       [Required]
       string Title,
       string Description,
       [Required]
       DateTime DueDate,
       string Priority,
       string Status
   );
}
