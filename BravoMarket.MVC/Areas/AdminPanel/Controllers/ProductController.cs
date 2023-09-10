using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    public class ProductController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products
                .Include(product => product.CategoryProducts)
                .ThenInclude(cp => cp.Category)
                .ToList();

            var viewModel = new ProductViewModel
            {
                Products = products,
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            var categories = _dbContext.Categories.ToList();
            var categoryForViewModel = categories.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            var model = new ProductCreateViewModel
            {
                CategoryListItems = categoryForViewModel,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CategoryListItems = _dbContext.Categories
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();

                return View(model);
            }

            if (model.Image != null && model.Image.Length > 0)
            {
                var directoryPath = Path.Combine(Constants.ImagePath, "products");
                Directory.CreateDirectory(directoryPath);

                var fileName = await model.Image.GenerateFile(directoryPath);

                model.ImageUrl = Path.Combine("products", fileName);
            }

            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.Name == model.Name);

            if (existingProduct != null)
            {
                ModelState.AddModelError(string.Empty, "This product already exists");
                model.CategoryListItems = _dbContext.Categories
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();

                return View(model);
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Count = model.Count,
                ImageUrl = model.ImageUrl
            };

            var categoryProducts = new List<CategoryProduct>();

            foreach (var categoryId in model.CategoryIds)
            {
                categoryProducts.Add(new CategoryProduct
                {
                    CategoryId = categoryId,
                    Product = product,
                });
            }

            product.CategoryProducts = categoryProducts;

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _dbContext.Products
                .Include(x => x.CategoryProducts)
                .ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var categoryForViewModel = product.CategoryProducts.Select(x =>
                new SelectListItem(x.Category.Name, x.Category.Id.ToString())
            ).ToList();

            var availableCategories = _dbContext.Categories.ToList();

            var viewModel = new ProductUpdateViewModel
            {
                Id = product.Id,
                Name = product.Name,
                RemovedCategories = categoryForViewModel,
                AvailableCategories = availableCategories
                    .Select(b => new SelectListItem(b.Name, b.Id.ToString()))
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProductUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableCategories = await _dbContext.Categories
                    .Select(b => new SelectListItem(b.Name, b.Id.ToString()))
                    .ToListAsync();

                return View(model);
            }

            var product = await _dbContext.Products
                .Include(x => x.CategoryProducts)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            if (model.Image != null && model.Image.Length > 0)
            {
                var directoryPath = Path.Combine(Constants.ImagePath, "products");
                Directory.CreateDirectory(directoryPath);

                var fileName = await model.Image.GenerateFile(directoryPath);

                model.ImageUrl = Path.Combine("products", fileName);

                var oldImageUrl = product.ImageUrl;

                if (!string.IsNullOrEmpty(oldImageUrl))
                {
                    var oldImagePath = Path.Combine(Constants.ImagePath, oldImageUrl);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Count = model.Count;
            product.ImageUrl = model.ImageUrl;

            if (model.RemovedCategoryIds != null)
            {
                var removedCategoryIds = model.RemovedCategoryIds.Distinct().ToList();

                foreach (var categoryId in removedCategoryIds)
                {
                    var categoryProductToRemove = product.CategoryProducts
                        .FirstOrDefault(x => x.CategoryId == categoryId);

                    if (categoryProductToRemove != null)
                    {
                        product.CategoryProducts.Remove(categoryProductToRemove);
                    }
                }
            }

            if (model.AddedCategoryIds != null && model.AddedCategoryIds.Any())
            {
                var addedCategoryIds = model.AddedCategoryIds.Distinct().ToList();

                foreach (var categoryId in addedCategoryIds)
                {
                    var category = await _dbContext.Categories.FindAsync(categoryId);

                    if (category != null)
                    {
                        product.CategoryProducts.Add(new CategoryProduct
                        {
                            Category = category,
                        });
                    }
                }
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var photoToDelete = product.ImageUrl;

            if (!string.IsNullOrEmpty(photoToDelete))
            {
                var imagePath = Path.Combine(Constants.ImagePath, photoToDelete);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
