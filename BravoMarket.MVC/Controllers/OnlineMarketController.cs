using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class OnlineMarketController : Controller
    {
        private readonly AppDbContext _dbContext;

        public OnlineMarketController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();

            var viewModel = new CategoryViewModel
            {
                Categories = categories,
            };

            return View(viewModel);
        }

        public IActionResult Products(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var category = _dbContext.Categories
                .Include(c => c.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var subCategories = _dbContext.Categories
                .Where(subCat => subCat.ParentCategoryId == category.Id)
                .ToList();

            var parentCategory = category;

            if (subCategories == null || subCategories.Count == 0)
            {
                if (category.ParentCategoryId.HasValue)
                {
                    parentCategory = _dbContext.Categories
                        .FirstOrDefault(cat => cat.Id == category.ParentCategoryId);

                    subCategories = _dbContext.Categories
                        .Where(subCat => subCat.ParentCategoryId == parentCategory.Id)
                        .ToList();
                }
            }

            var products = category.CategoryProducts.Select(cp => cp.Product).ToList();

            var viewModel = new ProductViewModel
            {
                Category = category,
                SubCategories = subCategories,
                ParentCategory = parentCategory,
                Products = products,
            };

            return View(viewModel);
        }

        public IActionResult Search(string searchedProductsTitle)
        {
            var searchedProducts = _dbContext.Products
                .Where(x => x.Name.ToLower().Contains(searchedProductsTitle.ToLower()))
                .ToList();

            return PartialView("_SearchedProductsPartial", searchedProducts);
        }
    }
}
