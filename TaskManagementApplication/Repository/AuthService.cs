using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Helpers;

namespace TaskManagementApplication.Repository
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthService(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public TokenResponse Login(LoginDto dto)
        {
            var user = _repo.GetUser(dto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return new TokenResponse(null, dto.Username, user?.Role, "401");

            var accessToken = JwtHelper.GenerateAccessToken(user.UserId, _config);
            var refreshToken = Guid.NewGuid().ToString();

            _repo.SaveRefreshToken(user.UserId, refreshToken,
                DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:RefreshTokenDays"])));

            return new TokenResponse(accessToken, dto.Username,user?.Role,null);
        }
        public void Register(RegisterDto dto)
        {
            if (_repo.GetUser(dto.Username) != null)
                throw new Exception("Username already exists");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            _repo.CreateUser(dto.Username, passwordHash,dto.Role);
        }
    }

}
