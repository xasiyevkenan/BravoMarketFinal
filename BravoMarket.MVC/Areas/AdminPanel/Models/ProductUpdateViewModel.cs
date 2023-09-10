using Microsoft.AspNetCore.Mvc.Rendering;

namespace BravoMarket.MVC.Areas.AdminPanel.Models
{
    public class ProductUpdateViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Count { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }

        public List<SelectListItem>? RemovedCategories { get; set; }
        public List<int>? RemovedCategoryIds { get; set; }
        public List<SelectListItem>? AvailableCategories { get; set; }
        public List<int>? AddedCategoryIds { get; set; } 
    }
}
