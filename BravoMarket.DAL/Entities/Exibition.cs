
namespace BravoMarket.DAL.Entities
{
    public class Exibition : TimeStample
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NewsId { get; set; }

        public News News { get; set; }
    }
}
