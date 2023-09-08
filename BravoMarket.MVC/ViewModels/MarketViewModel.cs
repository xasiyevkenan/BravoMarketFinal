using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class MarketViewModel
    {
        public List<Market> Markets { get; set; }
        public List<MarketType> MarketTypes { get; set; }
    }
}
