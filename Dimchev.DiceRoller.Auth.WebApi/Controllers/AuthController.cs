using Dimchev.DiceRoller.Auth.Core.Contracts.Services;
using Dimchev.DiceRoller.Auth.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Dimchev.DiceRoller.Auth.WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IUserService userService, ITokenService tokenService) : Controller
    {
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserDto dto)
        {
            var user = await userService.CreateUserAsync(dto);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> GenerateToken([FromBody] LoginDto dto)
        {
            var token = await userService.LoginAsync(dto);
            return Ok(new { Token = token });
        }
    }
}
