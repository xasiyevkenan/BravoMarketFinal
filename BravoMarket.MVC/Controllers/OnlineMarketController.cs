using Microsoft.AspNetCore.Mvc;

namespace BravoMarket.MVC.Controllers
{
    public class OnlineMarketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
