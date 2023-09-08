
namespace BravoMarket.DAL.Entities
{
    public class CorporativeClientService : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonInner { get; set; }
        public int CorporativeId { get; set; }

        public Corporative Corporative { get; set; }
    }
}
