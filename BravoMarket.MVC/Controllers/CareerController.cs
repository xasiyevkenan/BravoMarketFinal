using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class CareerController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CareerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var career = _dbContext.Career
                .Include(career => career.CareerBanner)
                .Include(career => career.Preference)
                .Include(career => career.Promises)
                .Include(career => career.Vacancies)
                .Include(career => career.Employer)
                .Include(career => career.Employer)
                .FirstOrDefault();

            var preference = _dbContext.Preference
                .Include(preference => preference.Paragraphs)
                .FirstOrDefault();

            var vacancies = _dbContext.Vacancies
                .Include(vacancy => vacancy.VacancyType)
                .ToList();

            var careerBanner = _dbContext.CareerBanner.FirstOrDefault();
            var employer = _dbContext.Employer.FirstOrDefault();
            var preferenceParagraph = _dbContext.PreferenceParagraphs.ToList();
            var vacancyTypes = _dbContext.VacancyTypes.ToList();
            var promises = _dbContext.Promises.ToList();

            var viewModel = new CareerViewModel
            {
                Career = career,
                Preference = preference,
                Vacancies = vacancies,
                CareerBanner = careerBanner,
                Employer = employer,
                PreferenceParagraphs = preferenceParagraph,
                VacancyTypes = vacancyTypes,
                Promises = promises,
            };

            return View(viewModel);
        }
    }
}
