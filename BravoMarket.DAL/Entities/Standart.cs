
namespace BravoMarket.DAL.Entities
{
    public class Standart : TimeStample
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int AboutId { get; set; }

        public About About { get; set; }

        public ICollection<StandartThree> StandartsThree { get; set; }
    }
}
