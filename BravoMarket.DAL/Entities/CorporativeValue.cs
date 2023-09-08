
namespace BravoMarket.DAL.Entities
{
    public class CorporativeValue : TimeStample
    {
        public string IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AboutId { get; set; }

        public About About { get; set; }
    }
}
