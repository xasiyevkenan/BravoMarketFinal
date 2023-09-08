using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class FooterViewModel
    {
        public Footer Footer { get; set; }

        public List<Company> Companies { get; set; }
        public List<Law> Laws { get; set; }
        public List<Other> Others { get; set; }
        public List<FooterAbout> FooterAbouts { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }
}
