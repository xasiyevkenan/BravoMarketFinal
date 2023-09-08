using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public FooterViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var footer = _dbContext.Footer
                .Include(footer => footer.Companies)
                .Include(footer => footer.Laws)
                .Include(footer => footer.FooterAbout)
                .Include(footer => footer.Others)
                .Include(footer => footer.SocialMedias)
                .FirstOrDefault();

            var companies = _dbContext.Companies.ToList();
            var laws = _dbContext.Laws.ToList();
            var footerAbouts = _dbContext.FooterAbouts.ToList();
            var socialMedial = _dbContext.SocialMedias.ToList();
            var others = _dbContext.Others.ToList();

            var viewModel = new FooterViewModel
            {
                Footer = footer,
                Companies = companies,
                Laws = laws,
                FooterAbouts = footerAbouts,
                Others = others,
                SocialMedias = socialMedial
            };

            return View(viewModel);
        }
    }
}
