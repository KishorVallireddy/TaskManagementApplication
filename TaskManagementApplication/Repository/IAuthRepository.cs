using TaskManagementApplication.Models;

namespace TaskManagementApplication.Repository
{
    public interface IAuthRepository
    {
        User GetUser(string username);

        void CreateUser(string username, string passwordHash, string role);
        void SaveRefreshToken(int userId, string refreshToken, DateTime expiresAt);
    }
}
