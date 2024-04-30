using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Diagnostics;

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
        public IActionResult Index()
        {
            return View(new List<GetAPIDTOs>());
        }
    }
}
