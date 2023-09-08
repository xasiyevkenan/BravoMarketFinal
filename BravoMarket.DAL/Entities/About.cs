
namespace BravoMarket.DAL.Entities
{
    public class About : TimeStample
    {
        public string HeadTitle { get; set; }
        public string HeadDescription { get; set; }
        public string ValueTitle { get; set; }
        public string ValueDescription { get; set; }
        public string FirstBannerImageUrl { get; set; }
        public string LastBannerImageUrl { get; set; }
        public string BannerTitle { get; set; }

        public Standart Standart { get; set; }

        public ICollection<Vision> Visions { get; set; }
        public ICollection<Value> Values { get; set; }
        public ICollection<CorporativeValue> CorporativeValues { get; set; }
    }
}
