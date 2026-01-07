using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Repository;

namespace TaskManagementApplication.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service) => _service = service;
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
              var result=_service.Login(dto);
            if(!string.IsNullOrEmpty(result.errorMessage)&&result.errorMessage=="401")
            {
                return Unauthorized();
                ;
            }
            return Ok(new { token = result.AccessToken, userName = result.RefreshToken,role=result.Role });
        }
          

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            _service.Register(dto);
            return Ok("User registered successfully");
        }
    }
}
