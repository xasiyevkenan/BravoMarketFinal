using Microsoft.AspNetCore.Mvc.Rendering;

namespace BravoMarket.MVC.Areas.AdminPanel.Models
{
    public class CategoryUpdateViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }

        public List<SelectListItem>? RemovedProducts { get; set; }
        public List<int>? RemovedProductIds { get; set; }
        public List<SelectListItem>? AvailableProducts { get; set; }
        public List<int>? AddedProductIds { get; set; }
    }
}
