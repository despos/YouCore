//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Starter kit
//

using Microsoft.AspNetCore.Mvc;
using YouCore.Server.Application;

namespace YouCore.Server.Controllers
{
    public class HomeController : StarterKitController
    {
        private readonly HomeService _homeService;

        public HomeController(HomeService service)
        {
            _homeService = service;
        }

        public IActionResult Index()
        {
            var model = _homeService.GetHomeViewModel();
            return View(model);
        }
    }
}