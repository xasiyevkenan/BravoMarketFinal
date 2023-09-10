using Microsoft.AspNetCore.Mvc;
using BravoMarket.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using BravoMarket.MVC.ViewModels;

namespace BravoMarket.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
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

            var advantage = _dbContext.Advantages
                .Include(advantage => advantage.İndicators)
                .Include(advantage => advantage.AdvantagesThree)
                .FirstOrDefault();

            var sliders = _dbContext.IndexSliders.ToList();
            var dots = _dbContext.SliderDots.ToList();
            var career = _dbContext.Career.FirstOrDefault();

            var viewModel = new HomeViewModel
            {
                IndexSliders = sliders,
                SliderDots = dots,
                Special = special,
                Advantage = advantage,
                Career = career,
            };

            return View(viewModel);
        }
    }
}
