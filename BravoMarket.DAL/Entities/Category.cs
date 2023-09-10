using System.Threading.Tasks;

namespace BravoMarket.DAL.Entities
{
    public class Category : TimeStample
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public string? ImageUrl { get; set; }
        public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; } 
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
