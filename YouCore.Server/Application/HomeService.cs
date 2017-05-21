//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Starter kit
//

using Microsoft.Extensions.Options;
using YouCore.Server.Common;
using YouCore.Server.Models;

namespace YouCore.Server.Application
{
    public class HomeService : ApplicationServiceBase
    {
        public HomeService(IOptions<GlobalConfig> config)
        {
            Settings = config.Value;
        }

        public HomeViewModel GetHomeViewModel()
        {
            return new HomeViewModel(Settings.Title);
        }
    }
}