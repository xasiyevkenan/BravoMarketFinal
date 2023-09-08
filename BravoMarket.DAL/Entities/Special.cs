
namespace BravoMarket.DAL.Entities
{
    public class Special : TimeStample
    {
        public string HeaderTitle { get; set; }
        public string HeaderDescription { get; set; }
        public string ButtonInner { get; set; }
        public ICollection<SpecialOffer> SpecialOffers { get; set; }
        public ICollection<MarketType> MarketTypes { get; set; }
    }
}
