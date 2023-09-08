using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public NewsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var news = _dbContext.News
                .Include(news => news.KSMActivities)
                .ToList();

            var ksmActivities = _dbContext.KSMActivities.ToList();

            var viewModel = new NewsViewModel
            {
                News = news,
                KSMActivities = ksmActivities,
            };

            return View(viewModel);
        }

        public IActionResult Exibition()
        {
            var news = _dbContext.News
             .Include(news => news.Exibitions)
             .ToList();

            var exibitions = _dbContext.Exibitions.ToList();

            var viewModel = new NewsViewModel
            {
                News = news,
                Exibitions = exibitions,
            };

            return View(viewModel);
        }

        public IActionResult KSMDetails(int? id)
        {
            var ksmActivities = _dbContext.KSMActivities.Take(3).ToList();
            var ksmActivity = _dbContext.KSMActivities.Find(id);

            var viewModel = new NewsViewModel
            {
                KSMActivities = ksmActivities,
                KSMActivity = ksmActivity,
            };

            if (id == null) return BadRequest();

            if (ksmActivity == null) return NotFound();

            return View(viewModel);
        }

        public IActionResult ExibitionDetails(int? id)
        {
            var exibitions = _dbContext.Exibitions.Take(3).ToList();
            var exibition = _dbContext.Exibitions.Find(id);

            var viewModel = new NewsViewModel
            {
                Exibitions = exibitions,
                Exibition = exibition,
            };

            if (id == null) return BadRequest();

            if (exibition == null) return NotFound();

            return View(viewModel);
        }
    }
}
