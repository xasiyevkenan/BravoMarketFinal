
namespace BravoMarket.DAL.Entities
{
    public class Value : TimeStample
    {
        public string Name { get; set; }
        public int AboutId { get; set; }

        public About About { get; set; }
    }
}
