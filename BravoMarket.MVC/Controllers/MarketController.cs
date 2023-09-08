using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class MarketController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MarketController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var markets = _dbContext.Markets
                .Include(market => market.MarketType)
                .ToList();

            var marketTypes = _dbContext.MarketTypes.ToList();

            var viewModel = new MarketViewModel
            {
                Markets = markets,
                MarketTypes = marketTypes,
            };

            return View(viewModel);
        }
    }
}
