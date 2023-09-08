
namespace BravoMarket.DAL.Entities
{
    public class Company : TimeStample
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int FooterId { get; set; }

        public Footer Footer { get; set; }
    }
}
