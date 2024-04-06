using CarBook.Application.Dtos.AuthDtos;
using CarBook.Application.Interfaces.AuthInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthsController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        //Route for Seeding My roles to Db
        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seedRoles = await _authRepository.SeedRolesAsync();
            return Ok(seedRoles);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var registerResult = await _authRepository.RegisterAsync(registerDto);

            if (registerResult.IsSucceed)
                return Ok(registerResult);

            return BadRequest(registerResult);
        }

        //Route ---> login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var loginResult = await _authRepository.LoginAsync(loginDto);
            if (loginResult.IsSucceed)
                return Ok(loginResult);
            return Unauthorized(loginResult);
        }

    }
}
