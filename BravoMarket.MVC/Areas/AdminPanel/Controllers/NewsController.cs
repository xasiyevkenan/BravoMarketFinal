using Microsoft.AspNetCore.Mvc;

namespace BravoMarket.MVC.Areas.AdminPanel.Controllers
{
    public class NewsController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
