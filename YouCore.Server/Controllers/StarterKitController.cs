//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Starter kit
//

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YouCore.Server.Common;
using YouCore.Server.Models;

namespace YouCore.Server.Controllers
{
    public class StarterKitController : Controller
    {
        protected GlobalConfig Configuration { get; set; }

        public IActionResult Error([Bind(Prefix = "id")] int statusCode = 0)
        {
            var model = new ViewModelBase(Configuration.Title);
            model.StatusCode = statusCode;

            // NOTE: THIS IS _NOT_ A REDIRECT (no longer SERVER object available)

            // Collect error information
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (error == null)
            {
                return View(model);
            }

            var ex = error.Error;
            model.ErrorMessage = string.Format("{0} ({1})", ex.Message, ex.GetType());
            return View(model);
        }
    }
}