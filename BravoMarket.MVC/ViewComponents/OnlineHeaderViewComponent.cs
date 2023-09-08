using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.ViewComponents
{
    public class OnlineHeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public OnlineHeaderViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _dbContext.Categories.ToList();

            var viewModel = new OnlineMarketViewModel()
            {
                Categories = categories,
            };

            return View(viewModel);
        }
    }
}
