using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public HeaderViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var header = _dbContext.Header
                .Include(header => header.LeftNavigations)
                .Include(header => header.RightNavigations)
                .FirstOrDefault();

            var leftNavigations = _dbContext.LeftNavigations.ToList();
            var rightNavigations = _dbContext.RightNavigations.ToList();

            var viewModel = new HeaderViewModel
            {
                Header = header,
                LeftNavigations = leftNavigations,
                RightNavigations = rightNavigations
            };

            return View(viewModel);
        }
    }
}
