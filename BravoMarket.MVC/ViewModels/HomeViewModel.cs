using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class HomeViewModel 
    {
        public Special Special { get; set; }
        public Advantage Advantage { get; set; }
        public Career Career { get; set; }

        public List<IndexSlider> IndexSliders { get; set; }
        public List<SliderDot> SliderDots { get; set; }
    }
}
