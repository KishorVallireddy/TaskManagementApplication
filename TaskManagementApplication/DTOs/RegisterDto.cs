namespace TaskManagementApplication.DTOs
{
    public record RegisterDto(
     string Username,
     string Password,
     string Role="User"
 );
}
