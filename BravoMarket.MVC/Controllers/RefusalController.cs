using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class RefusalController : Controller
    {
        private readonly AppDbContext _dbContext;

        public RefusalController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var refusals = _dbContext.Refusals
                .Include(refusal => refusal.RefusalInformations)
                .ToList();

            var refusalInfos = _dbContext.Refusalİnfos.ToList();

            var viewModel = new RefusalViewModel
            {
                Refusals = refusals,
                Refusalİnfos = refusalInfos,
            };

            return View(viewModel);
        }
    }
}
