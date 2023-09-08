using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class CardViewModel
    {
        public Card Card { get; set; }

        public List<CardType> CardTypes { get; set; }
        public List<CardImage> CardImages { get; set; }
    }
}
