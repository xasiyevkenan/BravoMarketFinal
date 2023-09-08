
namespace BravoMarket.DAL.Entities
{
    public class Advantage : TimeStample
    {
        public string HeaderTitle { get; set; }
        public string HeaderDescription { get; set; }
        public ICollection<İndicator> İndicators { get; set; }
        public ICollection<AdvantageThree> AdvantagesThree { get; set; }
    }
}
