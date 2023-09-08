using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BravoMarket.MVC.Controllers
{
    public class CardController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CardController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var card = _dbContext.Cards
                .Include(card => card.CardTypes)
                .Include(card => card.CardImages)
                .FirstOrDefault();

            var cardTypes = _dbContext.CardTypes.ToList();
            var cardİmages = _dbContext.CardImages.ToList();

            var viewModel = new CardViewModel
            {
                Card = card,
                CardTypes = cardTypes,
                CardImages = cardİmages,
            };

            return View(viewModel);
        }
    }
}
