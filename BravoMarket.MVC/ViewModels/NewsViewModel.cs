using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class NewsViewModel
    {
        public List<News> News { get; set; }
        public List<Exibition> Exibitions { get; set; }
        public List<KSMActivity> KSMActivities { get; set; }

        public Exibition Exibition { get; set; }
        public KSMActivity KSMActivity { get; set; }
    }
}
