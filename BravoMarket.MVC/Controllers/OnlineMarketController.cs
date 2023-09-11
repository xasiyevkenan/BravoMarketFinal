using BravoMarket.DAL.DataContext;
using BravoMarket.DAL.Entities;
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

        public IActionResult Search(string? searchedProductsTitle)
        {
            CategoryViewModel viewModel = new CategoryViewModel();

            if (searchedProductsTitle != null)
            {
                searchedProductsTitle = searchedProductsTitle.ToLower();

                var searchedProducts = _dbContext.Products
                    .Include(x => x.CategoryProducts)
                    .ThenInclude(x => x.Category)
                    .Where(x => x.Name.ToLower().Contains(searchedProductsTitle))
                    .ToList();

                var categories = searchedProducts
                       .Select(product => product.CategoryProducts.FirstOrDefault()?.Category)
                       .Where(category => category != null)
                       .ToList();

                viewModel.Products = searchedProducts;
                viewModel.Category = categories.FirstOrDefault();
            }

            return PartialView("_SearchedProductsPartial", viewModel);
        }
    }
}
