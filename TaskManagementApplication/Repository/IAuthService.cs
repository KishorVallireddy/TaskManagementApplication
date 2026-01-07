using TaskManagementApplication.DTOs;

namespace TaskManagementApplication.Repository
{
    public interface IAuthService
    {
        TokenResponse Login(LoginDto dto);

        void Register(RegisterDto dto);
    }
}
