using Microsoft.AspNetCore.Mvc;
using Shared.Statics.Models;

namespace Presentation.Controllers
{
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;

        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Docs")]
        public IActionResult Index(string endpoint = "")
        {
            var list = new GetAPIDTO();
            return View(list);
        }
    }
}
