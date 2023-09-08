
namespace BravoMarket.DAL.Entities
{
    public class CorporativeBanner : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string BGColor { get; set; }
        public string BottomTitle { get; set; }
        public string BottomColor { get; set; }
        public int CorporativeId { get; set; }

        public Corporative Corporative { get; set; }
    }
}
