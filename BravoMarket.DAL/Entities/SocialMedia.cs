
namespace BravoMarket.DAL.Entities
{
    public class SocialMedia : TimeStample
    {
        public string ClassName { get; set; }
        public string LinkUrl { get; set; }
        public int Footerid { get; set; }

        public Footer Footer { get; set; }
    }
}
