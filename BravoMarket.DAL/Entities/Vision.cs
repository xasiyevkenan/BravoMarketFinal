
namespace BravoMarket.DAL.Entities
{
    public class Vision : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int AboutId { get; set; }

        public About About { get; set; }
    }
}
