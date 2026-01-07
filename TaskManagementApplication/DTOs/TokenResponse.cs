namespace TaskManagementApplication.DTOs
{
    public record TokenResponse(

        string AccessToken, 
        string RefreshToken,
        string Role,
        string errorMessage
        );
}
