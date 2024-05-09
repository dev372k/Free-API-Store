using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        [HttpGet("sentiment")]
        public IActionResult Sentiment(string text)
        {
            try
            {
                return Ok(text);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Status = false, ErrorMessage = ex.Message, ErrorDetails = ex?.InnerException?.ToString() });
            }
        }
    }
}
