using BravoMarket.DAL.DataContext;
using BravoMarket.DAL.Entities;
using BravoMarket.MVC.Areas.AdminPanel.Data;
using BravoMarket.MVC.Areas.AdminPanel.Models;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Areas.AdminPanel.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categories = _dbContext.Categories
                .Include(categories => categories.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .ToList();

           var viewModel = new CategoryViewModel()
           {
               Categories= categories,
           };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            var products = _dbContext.Products.ToList();
            var productForViewModel = products.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            var model = new CategoryCreateViewModel
            {
                ProductListItems = productForViewModel,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ProductListItems = _dbContext.Products
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();

                return View(model);
            }

            if (model.Image != null && model.Image.Length > 0)
            {
                var directoryPath = Path.Combine(Constants.ImagePath, "catalogs");
                Directory.CreateDirectory(directoryPath);

                var fileName = await model.Image.GenerateFile(directoryPath);

                model.ImageUrl = Path.Combine("catalogs", fileName);
            }

            var existingCategory = _dbContext.Categories.FirstOrDefault(p => p.Name == model.Name);

            if (existingCategory != null)
            {
                ModelState.AddModelError(string.Empty, "This category already exists");
                model.ProductListItems = _dbContext.Categories
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();

                return View(model);
            }

            var category = new Category
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl
            };

            var categoryProducts = new List<CategoryProduct>();

            foreach (var productId in model.ProductIds)
            {
                categoryProducts.Add(new CategoryProduct
                {
                    Category = category,
                    ProductId = productId,
                });
            }

            category.CategoryProducts = categoryProducts;

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _dbContext.Categories
                .Include(x => x.CategoryProducts)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var productForViewModel = category.CategoryProducts.Select(x =>
                new SelectListItem(x.Product.Name, x.Product.Id.ToString())
            ).ToList();

            var availableProducts = _dbContext.Products.ToList();

            var viewModel = new CategoryUpdateViewModel
            {
                Id = category.Id,
                Name = category.Name,
                RemovedProducts = productForViewModel,
                AvailableProducts = availableProducts
                    .Select(b => new SelectListItem(b.Name, b.Id.ToString()))
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CategoryUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableProducts = await _dbContext.Products
                    .Select(b => new SelectListItem(b.Name, b.Id.ToString()))
                    .ToListAsync();

                return View(model);
            }

            var category = await _dbContext.Categories
                .Include(x => x.CategoryProducts)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            if (model.Image != null && model.Image.Length > 0)
            {
                var directoryPath = Path.Combine(Constants.ImagePath, "products");
                Directory.CreateDirectory(directoryPath);

                var fileName = await model.Image.GenerateFile(directoryPath);

                model.ImageUrl = Path.Combine("products", fileName);

                var oldImageUrl = category.ImageUrl;

                if (!string.IsNullOrEmpty(oldImageUrl))
                {
                    var oldImagePath = Path.Combine(Constants.ImagePath, oldImageUrl);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
            }

            category.Name = model.Name;
            category.ImageUrl = model.ImageUrl;

            if (model.RemovedProductIds != null)
            {
                var removedProductIds = model.RemovedProductIds.Distinct().ToList();

                foreach (var productId in removedProductIds)
                {
                    var categoryProductToRemove = category.CategoryProducts
                        .FirstOrDefault(x => x.ProductId == productId);

                    if (categoryProductToRemove != null)
                    {
                        category.CategoryProducts.Remove(categoryProductToRemove);
                    }
                }
            }

            if (model.AddedProductIds != null && model.AddedProductIds.Any())
            {
                var addedCategoryIds = model.AddedProductIds.Distinct().ToList();

                foreach (var categoryId in addedCategoryIds)
                {
                    var product = await _dbContext.Products.FindAsync(categoryId);

                    if (category != null)
                    {
                        category.CategoryProducts.Add(new CategoryProduct
                        {
                            Product = product,
                        });
                    }
                }
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var photoToDelete = category.ImageUrl;

            if (!string.IsNullOrEmpty(photoToDelete))
            {
                var imagePath = Path.Combine(Constants.ImagePath, photoToDelete);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
