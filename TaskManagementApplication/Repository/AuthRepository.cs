using Dapper;
using System.Data;
using TaskManagementApplication.Models;

namespace TaskManagementApplication.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbConnection _db;

        public AuthRepository(IDbConnection db) => _db = db;

        public User GetUser(string username) =>
            _db.QuerySingleOrDefault<User>(
                "SELECT * FROM Users WHERE Username=@u",
                new { u = username });
        public void CreateUser(string username, string passwordHash, string role)
        {
            _db.Execute(
                @"INSERT INTO Users (Username, PasswordHash, Role)
              VALUES (@u, @p, 'User')",
                new { u = username, p = passwordHash });
        }
        public void SaveRefreshToken(int userId, string token, DateTime expiry)
        {
            _db.Execute(
                "INSERT INTO RefreshTokens(UserId,Token,ExpiresAt) VALUES(@u,@t,@e)",
                new { u = userId, t = token, e = expiry });
        }
    }

}
