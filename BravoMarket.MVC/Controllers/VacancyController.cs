using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class VacancyController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly int _vacancyCount;

        public VacancyController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _vacancyCount = _dbContext.Vacancies.Count();
        }

        public IActionResult Index()
        {
            ViewBag.VacancyCount = _vacancyCount;

            var vacancies = _dbContext.Vacancies.Take(3).ToList();

            var viewModel = new VacancyViewModel
            {
                Vacancies = vacancies
            };

            return View(viewModel);
        }

        public IActionResult LoadVacancies(int skip)
        {
            var vacancies = _dbContext.Vacancies?.Skip(skip).Take(3).ToList();

            var viewModel = new VacancyViewModel
            {
                Vacancies = vacancies
            };

            return PartialView("_VacancyPartial", viewModel);
        }
    }
}
