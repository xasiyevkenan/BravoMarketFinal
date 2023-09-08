using BravoMarket.DAL.DataContext;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BravoMarket.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var contact = _dbContext.Contact
                .Include(c => c.Comment)
                .Include(c => c.ClientFAQs)
                .Include(c => c.ConsumerProtections)
                .FirstOrDefault();

            var comment = _dbContext.Comment
                .Include(c => c.CommentTypes)
                .FirstOrDefault();

            var clientFAQs = _dbContext.ClientFAQ
                .Include(cf => cf.Questions)
                .ToList();

            var clientFAQTitles = _dbContext.ClientFAQTitles
                .Include(cft => cft.Answers)
                .ToList();

            var consumerProtections = _dbContext.ConsumerProtection
                .Include(cp => cp.ConsumerProtectionInfos)
                .ToList();

            var commentTypes = _dbContext.CommentTypes.ToList();
            var clientFAQAnswers = _dbContext.ClientFAQAnswers.ToList();
            var consumerProtectionInfos = _dbContext.ConsumerProtectionInfos.ToList();

            var viewModel = new ContactViewModel
            {
                Contact = contact,
                Comment = comment,
                ClientFAQs = clientFAQs,
                CommentTypes = commentTypes,
                ClientFAQTitles = clientFAQTitles,
                ClientFAQAnswers = clientFAQAnswers,
                ConsumerProtections = consumerProtections,
                ConsumerProtectionInfos = consumerProtectionInfos,
            };

            return View(viewModel);
        }
    }
}

