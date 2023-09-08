using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BravoMarket.MVC.Controllers
{
    public class TermOfUseController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TermOfUseController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var termsOfUses = _dbContext.TermsOfUse.ToList();

            var viewModel = new TermOfUseViewModel
            {
                TermOfUse = termsOfUses
            };

            return View(viewModel);
        }
    }
}
