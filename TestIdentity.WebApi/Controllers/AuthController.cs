using Microsoft.AspNetCore.Mvc;
using TestIdentity.Application.DTOs;
using TestIdentity.Application.Interfaces;

namespace TestIdentity.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest dto)
    {
        var user = await _authService.RegisterAsync(dto);
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest dto)
    {
        var result = await _authService.LoginAsync(dto);
        return Ok(result);
    }
    // [HttpPost("refresh")]
    // public async Task<IActionResult> Refresh([FromBody] string refreshToken)
    // {
    //     var result = await _authService.RefreshTokenAsync(refreshToken);
    //     return Ok(result);
    // }

}
