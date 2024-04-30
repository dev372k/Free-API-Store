using Microsoft.AspNetCore.Mvc;
using Shared.Statics;
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
            var api = APIList.list.SelectMany(_ => _.APIs).FirstOrDefault(_ => (!string.IsNullOrEmpty(endpoint) ? _.UniqueName == endpoint: true));
            
            var list = new GetAPIDTO
            {
                GetAPIs = APIList.list,
                API = api
            };
            return View(list);
        }



    }
}


//new GetAPIs
//{
//    GroupBy = "Auth",
//    APIs = new List<API>
//                {
//                    new API
//                    {
//                        Id = 1,
//                        Name = "Login",
//                        Endpoint = "api/auth/login",
//                        Method = Shared.enMethodType.Post,
//                        Request = @"",
//                        Response = @"",
//                        UniqueName= "login",
//                    },
//                    new API
//                    {
//                        Id = 1,
//                        Name = "Register",
//                        Endpoint = "api/auth/register",
//                        Method = Shared.enMethodType.Post,
//                        Request = @"",
//                        Response = @"",
//                        UniqueName= "register",
//                    }
//                }
//}