using BravoMarket.DAL.DataContext;
using BravoMarket.DAL.Entities;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class CorporativeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CorporativeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var corporative = _dbContext.Corporative
                .Include(corporative => corporative.CorporativeBanner)
                .Include(corporative => corporative.CorporativeClientServices)
                .FirstOrDefault();

            var corporativeBanner = _dbContext.CorporativeBanner.FirstOrDefault();
            var corporativeClientServices = _dbContext.CorporativeClientService.ToList();

            var viewModel = new CorporativeViewModel
            {
                Corporative = corporative,
                CorporativeBanner = corporativeBanner,
                CorporativeClientServices = corporativeClientServices
            };

            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            var corporativeClientService = _dbContext.CorporativeClientService.Find(id);
            var commentTypes = _dbContext.CommentTypes.ToList();

            var viewModel = new CorporativeViewModel
            {
                CorporativeClientService = corporativeClientService,
                CommentTypes = commentTypes,
            };

            if (id == null) return BadRequest();

            if (corporativeClientService == null) return NotFound();

            return View(viewModel);
        }
    }
}
