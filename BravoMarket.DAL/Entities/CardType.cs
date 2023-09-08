
namespace BravoMarket.DAL.Entities
{
    public class CardType : TimeStample
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string ButtonInner { get; set; }
        public bool IsSlider { get; set; }
        public string? BgColor { get; set; }
        public ICollection<CardImage> CardImages { get; set; }
        public Card Card { get; set; }
    }
}
