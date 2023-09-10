using Microsoft.AspNetCore.Mvc.Rendering;

namespace BravoMarket.MVC.Areas.AdminPanel.Models
{
    public class CategoryCreateViewModel
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }

        public List<int>? ProductIds { get; set; }
        public List<SelectListItem>? ProductListItems { get; set; }
    }
}
