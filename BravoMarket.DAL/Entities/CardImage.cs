
namespace BravoMarket.DAL.Entities
{
    public class CardImage : TimeStample
    {
        public string ImageUrl { get; set; }
        public string? Dot { get; set; }
        public int CardTypeId { get; set; }
        public CardType CardType { get; set; }
    }
}
