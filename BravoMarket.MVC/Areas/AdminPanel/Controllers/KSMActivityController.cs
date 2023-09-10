using BravoMarket.DAL.DataContext;
using BravoMarket.DAL.Entities;
using BravoMarket.MVC.Areas.AdminPanel.Data;
using BravoMarket.MVC.Areas.AdminPanel.Models;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Areas.AdminPanel.Controllers
{
    public class KSMActivityController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public KSMActivityController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var ksmActivities = _dbContext.KSMActivities.ToList();

            var viewModel = new NewsViewModel
            {
                KSMActivities = ksmActivities,
            };

            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            var ksmActivity = _dbContext.KSMActivities.Find(id);

            var viewModel = new NewsViewModel
            {
                KSMActivity = ksmActivity,
            };

            if (id == null) return BadRequest();

            if (ksmActivity == null) return NotFound();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KSMActivityCreateViewModel viewModel)
        {
            try
            {
                if (viewModel.Image != null && viewModel.Image.Length > 0)
                {
                    var directoryPath = Path.Combine(Constants.ImagePath, "news");
                    Directory.CreateDirectory(directoryPath);

                    var fileName = await viewModel.Image.GenerateFile(directoryPath);

                    viewModel.ImageUrl = Path.Combine("news", fileName);

                    Console.WriteLine($"Image file saved at: {viewModel.ImageUrl}");
                }

                var ksmActivity = new KSMActivity
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    ImageUrl = viewModel.ImageUrl,
                    NewsId = 1,
                };

                if (ModelState.IsValid)
                {
                    _dbContext.KSMActivities.Add(ksmActivity);
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
            var ksmActivity = _dbContext.KSMActivities.Find(id);

            if (ksmActivity == null)
            {
                return NotFound();
            }

            var viewModel = new KSMActivityUpdateViewModel
            {
                Id = ksmActivity.Id,
                Title = ksmActivity.Title,
                Description = ksmActivity.Description,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, KSMActivityUpdateViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var ksmActivity = await _dbContext.KSMActivities.FindAsync(id);

                if (ksmActivity == null)
                {
                    return NotFound();
                }

                ksmActivity.Title = viewModel.Title;
                ksmActivity.Description = viewModel.Description;

                if (viewModel.Image != null && viewModel.Image.Length > 0)
                {
                    var directoryPath = Path.Combine(Constants.ImagePath, "news");
                    Directory.CreateDirectory(directoryPath);

                    var fileName = await viewModel.Image.GenerateFile(directoryPath);

                    viewModel.ImageUrl = Path.Combine("news", fileName);

                    ksmActivity.ImageUrl = viewModel.ImageUrl;
                }

                _dbContext.Update(ksmActivity);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ksmActivity = _dbContext.KSMActivities.Find(id);

            if (ksmActivity == null)
            {
                return NotFound();
            }

            return View(ksmActivity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ksmActivity = await _dbContext.KSMActivities.FindAsync(id);

            if (ksmActivity == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(ksmActivity.ImageUrl))
            {
                var imagePath = Path.Combine(Constants.ImagePath, ksmActivity.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _dbContext.KSMActivities.Remove(ksmActivity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}