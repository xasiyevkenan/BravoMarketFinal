using BravoMarket.DAL.DataContext;
using BravoMarket.DAL.Entities;
using BravoMarket.MVC.Areas.AdminPanel.Models;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BravoMarket.MVC.Areas.AdminPanel.Controllers
{
    public class VacancyController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public VacancyController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var vacancies = await _dbContext.Vacancies
                .Include(vacancy => vacancy.VacancyType)
                .ToListAsync();

            var vacancyTypes = await _dbContext.VacancyTypes
                .ToListAsync();

            var viewModel = new VacancyViewModel
            {
                Vacancies = vacancies,
                VacancyTypes = vacancyTypes,
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new VacancyCreateViewModel
            {
                VacancyTypeSelectList = GetVacancyTypeSelectList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VacancyCreateViewModel viewModel)
        {
            viewModel.VacancyTypeSelectList = GetVacancyTypeSelectList();

            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    if (state.Errors.Any())
                    {
                        foreach (var error in state.Errors)
                        {
                            var errorMessage = error.ErrorMessage;

                            if (key == nameof(viewModel.Title))
                            {
                                errorMessage = "Başlıq sahəsi mütləqdir və 100 simvoldan çox ola bilməz.";
                            }
                            else if (key == nameof(viewModel.SelectedVacancyTypeId))
                            {
                                errorMessage = "Vakansiya növü sahəsi mütləqdir.";
                            }
                            else if (key == nameof(viewModel.Adress))
                            {
                                errorMessage = "Ünvan sahəsi 100 simvoldan çox ola bilməz.";
                            }

                            ModelState.AddModelError(key, errorMessage);
                        }
                    }
                }

                return View(viewModel);
            }

            var vacancy = new Vacancy
            {
                Title = viewModel.Title,
                VacancyTypeId = viewModel.SelectedVacancyTypeId,
                Time = viewModel.Time,
                Adress = viewModel.Adress,
                CareerId = 1,
            };

            _dbContext.Vacancies.Add(vacancy);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var vacancy = await _dbContext.Vacancies.FindAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }

            _dbContext.Vacancies.Remove(vacancy);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var vacancy = _dbContext.Vacancies.Find(id);
            if (vacancy == null)
            {
                return NotFound();
            }

            var viewModel = new VacancyCreateViewModel
            {
                Id = vacancy.Id,
                Title = vacancy.Title,
                SelectedVacancyTypeId = vacancy.VacancyTypeId,
                Adress = vacancy.Adress,
                Time = vacancy.Time,
                VacancyTypeSelectList = GetVacancyTypeSelectList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(VacancyCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.VacancyTypeSelectList = GetVacancyTypeSelectList();
                return View(viewModel);
            }

            var existingVacancy = _dbContext.Vacancies.Find(viewModel.Id);
            if (existingVacancy == null)
            {
                return NotFound();
            }

            existingVacancy.Title = viewModel.Title;
            existingVacancy.VacancyTypeId = viewModel.SelectedVacancyTypeId;
            existingVacancy.Adress = viewModel.Adress;
            existingVacancy.Time = viewModel.Time;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private List<SelectListItem> GetVacancyTypeSelectList()
        {
            var vacancyTypes = _dbContext.VacancyTypes
                .Select(vt => new SelectListItem
                {
                    Value = vt.Id.ToString(),
                    Text = vt.Type.ToString(),
                })
                .ToList();

            return vacancyTypes;
        }
    }
}
