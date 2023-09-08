using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class HeaderViewModel
    {
        public Header Header { get; set; }

        public List<LeftNavigation> LeftNavigations { get; set; }
        public List<RightNavigation> RightNavigations { get; set; }
    }
}
