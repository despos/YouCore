// /////////////
// YouCore.StarterKit
// 
// Dino Esposito
// 2017

using YouCore.Server.Models;

namespace YouCore.Server.Application
{
    public interface IHomeService
    {
        HomeViewModel GetHomeViewModel();
    }
}