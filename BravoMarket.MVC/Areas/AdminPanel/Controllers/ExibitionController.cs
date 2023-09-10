using BravoMarket.DAL.DataContext;
using BravoMarket.DAL.Entities;
using BravoMarket.MVC.Areas.AdminPanel.Data;
using BravoMarket.MVC.Areas.AdminPanel.Models;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BravoMarket.MVC.Areas.AdminPanel.Controllers
{
    public class ExibitionController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public ExibitionController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var Exibitions = _dbContext.Exibitions.ToList();

            var viewModel = new NewsViewModel
            {
                Exibitions = Exibitions,
            };

            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            var exibition = _dbContext.Exibitions.Find(id);

            var viewModel = new NewsViewModel
            {
                Exibition = exibition,
            };

            if (id == null) return BadRequest();

            if (exibition == null) return NotFound();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExibitionCreateViewModel viewModel)
        {
            try
            {
                if (viewModel.Image != null && viewModel.Image.Length > 0)
                {
                    var directoryPath = Path.Combine(Constants.ImagePath, "exibitions");
                    Directory.CreateDirectory(directoryPath);

                    var fileName = await viewModel.Image.GenerateFile(directoryPath);

                    viewModel.ImageUrl = Path.Combine("exibitions", fileName);

                    Console.WriteLine($"Image file saved at: {viewModel.ImageUrl}");
                }

                var exibition = new Exibition
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    ImageUrl = viewModel.ImageUrl,
                    NewsId = 2,
                };

                if (ModelState.IsValid)
                {
                    _dbContext.Exibitions.Add(exibition);

                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var key in ModelState.Keys)
                    {
                        var error = ModelState[key].Errors.FirstOrDefault();
                        if (error != null)
                        {
                            ModelState.AddModelError(key, $"Error for {key}: {error.ErrorMessage}");
                        }
                    }
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var exibition = _dbContext.Exibitions.Find(id);

            if (exibition == null)
            {
                return NotFound();
            }

            var viewModel = new ExibitionUpdateViewModel
            {
                Id = exibition.Id,
                Title = exibition.Title,
                Description = exibition.Description,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ExibitionUpdateViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var exibition = await _dbContext.Exibitions.FindAsync(id);

                if (exibition == null)
                {
                    return NotFound();
                }

                exibition.Title = viewModel.Title;
                exibition.Description = viewModel.Description;

                if (viewModel.Image != null && viewModel.Image.Length > 0)
                {
                    var directoryPath = Path.Combine(Constants.ImagePath, "news");
                    Directory.CreateDirectory(directoryPath);

                    var fileName = await viewModel.Image.GenerateFile(directoryPath);

                    viewModel.ImageUrl = Path.Combine("news", fileName);

                    exibition.ImageUrl = viewModel.ImageUrl;
                }

                _dbContext.Update(exibition);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var exibition = _dbContext.Exibitions.Find(id);

            if (exibition == null)
            {
                return NotFound();
            }

            return View(exibition);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exibition = await _dbContext.Exibitions.FindAsync(id);

            if (exibition == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(exibition.ImageUrl))
            {
                var imagePath = Path.Combine(Constants.ImagePath, exibition.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _dbContext.Exibitions.Remove(exibition);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
