using Microsoft.AspNetCore.Mvc.Rendering;

namespace BravoMarket.MVC.Areas.AdminPanel.Models
{
    public class ProductCreateViewModel
    {

        public string Name { get; set; }
        public string Price { get; set; }
        public string Count { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile Image { get; set; }

        public List<int>? CategoryIds { get; set; } 
        public List<SelectListItem>? CategoryListItems{ get; set; }
    }
}
