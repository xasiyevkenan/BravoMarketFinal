using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class AboutViewModel
    {
        public About About { get; set; }
        public Standart Standart { get; set; }

        public List<StandartThree> StandartThrees { get; set; }
        public List<Vision> Visions { get; set; }
        public List<Value> Values { get; set; }
        public List<CorporativeValue> CorporativeValues { get; set;}
    }
}
