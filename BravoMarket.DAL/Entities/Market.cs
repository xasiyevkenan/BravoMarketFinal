
namespace BravoMarket.DAL.Entities
{
    public class Market : TimeStample
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
        public string Time { get; set; }
        public string MapLinkUrl { get; set; }
        public int MarketTypeId { get; set; }

        public MarketType MarketType { get; set; }
    }
}
