using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
