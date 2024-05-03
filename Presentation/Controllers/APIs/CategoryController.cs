using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.APIs;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Testing.." });
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(new { Message = "Testing.." });
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok(new { Message = "Testing.." });
    }

    [HttpPut("{id}")]
    public IActionResult Put()
    {
        return Ok(new { Message = "Testing.." });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete()
    {
        return Ok(new { Message = "Testing.." });
    }
}
