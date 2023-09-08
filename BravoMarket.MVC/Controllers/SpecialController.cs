using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class SpecialController : Controller
    {
        private readonly AppDbContext _dbContext;

        public SpecialController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var special = _dbContext.Special
                .Include(special => special.SpecialOffers)
                .Take(2)
                .Include(special => special.MarketTypes)
                .FirstOrDefault();

            var offers = _dbContext.SpecialOffers.ToList();
            var markettype = _dbContext.MarketTypes.ToList();

            var viewModel = new SpecialViewModel
            {
                Special = special,
                SpecialOffers = offers,
                MarketTypes = markettype,
            };

            return View(viewModel);
        }
    }
}
