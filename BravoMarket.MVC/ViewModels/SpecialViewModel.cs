using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class SpecialViewModel
    {
        public Special Special { get; set; }

        public List<SpecialOffer> SpecialOffers { get; set; }
        public List<MarketType> MarketTypes { get; set; }
    }
}
