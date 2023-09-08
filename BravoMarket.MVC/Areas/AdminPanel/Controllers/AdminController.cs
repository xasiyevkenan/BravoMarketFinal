using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BravoMarket.MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize (Roles ="Admin")]
    public class AdminController : Controller
    {
    
    }
}
