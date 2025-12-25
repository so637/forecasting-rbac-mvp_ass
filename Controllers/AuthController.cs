using Forecast.Api.Data;
using Forecast.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Forecast.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var user = _context.Users.FirstOrDefault(x =>
            x.Username == request.Username &&
            x.Password == request.Password);

        if (user == null)
            return Unauthorized("Invalid username or password");

        return Ok(new
        {
            user.Id,
            user.Username,
            user.Role
        });
    }
}
