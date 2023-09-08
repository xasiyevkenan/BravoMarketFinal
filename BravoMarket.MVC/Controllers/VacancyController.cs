using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class VacancyController : Controller
    {
        private readonly AppDbContext _dbContext;

        public VacancyController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var vacancies = _dbContext.Vacancies.ToList();

            var viewModel = new VacancyViewModel
            {
                Vacancies = vacancies
            };

            return View(viewModel);
        }
    }
}
