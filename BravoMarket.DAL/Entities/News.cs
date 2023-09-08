
namespace BravoMarket.DAL.Entities
{
    public class News : TimeStample
    {
        public string HeadTitle { get; set; }
        public string? HeadDescription { get; set; }

        public ICollection<KSMActivity> KSMActivities { get; set; }
        public ICollection<Exibition> Exibitions { get; set; }
    }
}
