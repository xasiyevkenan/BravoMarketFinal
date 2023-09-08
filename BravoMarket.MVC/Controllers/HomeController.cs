using Microsoft.AspNetCore.Mvc;
using BravoMarket.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using BravoMarket.MVC.ViewModels;

namespace BravoMarket.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public HomeController(AppDbContext appdbContext)
        {
            _dbcontext = appdbContext;
        }

        public IActionResult Index()
        {
            var special = _dbcontext.Special
                .Include(special => special.SpecialOffers)
                .Take(2)
                .Include(special => special.MarketTypes)
                .FirstOrDefault();

            var advantage = _dbcontext.Advantages
                .Include(advantage => advantage.İndicators)
                .Include(advantage => advantage.AdvantagesThree)
                .FirstOrDefault();

            var sliders = _dbcontext.IndexSliders.ToList();
            var dots = _dbcontext.SliderDots.ToList();
            var career = _dbcontext.Career.FirstOrDefault();

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
