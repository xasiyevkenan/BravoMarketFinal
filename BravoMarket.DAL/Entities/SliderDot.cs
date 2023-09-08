
namespace BravoMarket.DAL.Entities
{
    public class SliderDot : TimeStample
    {
        public string ImageUrl { get; set; }
        public int IndexSliderId { get; set; }
        public IndexSlider IndexSlider { get; set; }
    }
}
