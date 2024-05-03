using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.APIs;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    [HttpPost("login")]
    public IActionResult Login()
    {
        return Ok(new { Message = "Testing.." });
    }

    [HttpPost("register")]
    public IActionResult Register()
    {
        return Ok(new { Message = "Testing.." });
    }
}
