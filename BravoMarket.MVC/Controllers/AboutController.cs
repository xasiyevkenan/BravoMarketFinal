using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AboutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var about = _dbContext.About
                .Include(a => a.Visions)
                .Include(a => a.Values)
                .Include(a => a.CorporativeValues)
                .Include(a => a.Standart)
                .FirstOrDefault();

            var standart = _dbContext.Standart
                .Include(s => s.StandartsThree)
                .FirstOrDefault();

            var standartsThree = _dbContext.StandartThrees.ToList();
            var visions = _dbContext.Visions.ToList();
            var values = _dbContext.Values.ToList();
            var corporateValues = _dbContext.CorporativeValues.ToList();

            var viewModel = new AboutViewModel
            {
                About = about,
                Standart = standart,
                StandartThrees = standartsThree,
                Visions = visions,
                Values = values,
                CorporativeValues = corporateValues,
            };

            return View(viewModel);
        }
    }
}
