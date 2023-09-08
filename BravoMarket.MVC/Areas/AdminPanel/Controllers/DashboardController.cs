using Microsoft.AspNetCore.Mvc;

namespace BravoMarket.MVC.Areas.AdminPanel.Controllers
{
    public class DashboardController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
