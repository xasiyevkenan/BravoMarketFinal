
namespace BravoMarket.DAL.Entities
{
    public class Footer : TimeStample
    {
        public string LogoUrl { get; set; }
        public string CopyWrite { get; set; }
        public string Creator { get; set; }

        public ICollection<Law> Laws { get; set; }
        public ICollection<Other> Others { get; set; }
        public ICollection<FooterAbout> FooterAbout { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<SocialMedia> SocialMedias { get; set; }
    }
}
