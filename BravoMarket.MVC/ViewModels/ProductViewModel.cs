using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> SubCategories { get; set; }
        public Category Category { get; set; }
        public Category ParentCategory { get; set; }
    }
}
