using Microsoft.AspNetCore.Mvc;

namespace AlbumShop.Controllers{
    public class HomeController : Controller{

        public IActionResult Index() => View();
    }
}