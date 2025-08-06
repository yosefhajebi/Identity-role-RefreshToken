using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestIdentity.Application.Interfaces;

namespace TestIdentity.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    [HttpGet("{username}")]
    public async Task<IActionResult> GetByUsername(string username)
    {
        var user = await _userService.GetByUsernameAsync(username);
        if (user == null) return NotFound();
        return Ok(user);
    }
}
